using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Backups;

namespace BackupsExtra
{
        public class FileLoader
        {
            public static void Save(BackupJob backupJob, string file)
            {
                var fileOut = new StreamWriter(file, false, Encoding.UTF8);
                fileOut.WriteLine(backupJob.Name);
                fileOut.WriteLine(backupJob.Repository.Storage);
                fileOut.WriteLine("job objects:");
                foreach (string jobObject in backupJob.JobObjects)
                {
                    fileOut.WriteLine(jobObject);
                }

                foreach (RestorePoint restorePoint in backupJob.RestorePoints)
                {
                    fileOut.WriteLine("restore point:");
                    fileOut.WriteLine(restorePoint.Name);
                    fileOut.WriteLine(restorePoint.DateCreation);
                    foreach (string jobObject in restorePoint.Files)
                    {
                        fileOut.WriteLine(jobObject);
                    }
                }

                fileOut.Close();
            }

            public static BackupJob Load(string file)
            {
                var fileIn = new StreamReader(file, Encoding.UTF8);
                string jobName = fileIn.ReadLine();
                string jobDestination = fileIn.ReadLine();
                if (fileIn.ReadLine() != "job objects:")
                    throw new InvalidDataException("Invalid file");
                var jobObjects = new List<string>();
                string newLine = fileIn.ReadLine();
                while (newLine != "restore point:")
                {
                    jobObjects.Add(new string(newLine));
                    newLine = fileIn.ReadLine();
                }

                var restorePoints = new List<RestorePoint>();
                string creationTimeFormat = "dd.MM.yyyy HH:mm:ss";
                var provider = new CultureInfo("de-DE");
                while (newLine != null)
                {
                    string restorePointName = fileIn.ReadLine();
                    string creationTime = fileIn.ReadLine();
                    var restorePointJobObj = new List<string>();
                    newLine = fileIn.ReadLine();
                    while (newLine != "restore point:" && newLine != null)
                    {
                        restorePointJobObj.Add(new string(newLine));
                        newLine = fileIn.ReadLine();
                    }

                    var newRestorePoint = new RestorePoint(restorePointName, DateTime.ParseExact(creationTime, creationTimeFormat, provider), restorePointJobObj);
                    restorePoints.Add(newRestorePoint);
                }

                fileIn.Close();
                var repository = new TestRepository();
                var newBackupJob = new BackupJob(jobName, new SplitStorageAlgorithm(repository), 10, jobObjects, restorePoints);
                return newBackupJob;
            }
        }
}
