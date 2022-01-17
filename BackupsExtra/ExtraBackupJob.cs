using System;
using System.Collections.Generic;
using Backups;

namespace BackupsExtra
{
    public class ExtraBackupJob : BackupJob
    {
        private Algorithm _algorithm;

        public ExtraBackupJob(string name, Algorithm algorithm, int maxPointCount, TestLogger logger, List<string> jobObjects = default, List<RestorePoint> restorePoints = default)
            : base(name, algorithm, maxPointCount, jobObjects, restorePoints)
        {
            _algorithm = algorithm;
            Repository = algorithm.Repository;
            Repository.CreateBackupDir(name);
            Logger = logger;
            Logger.Write("BackupJobCreated");
        }

        public TestLogger Logger { get; }

        public new void AddFile(string path)
        {
            JobObjects.Add(path);
            Logger.Write("AddFile");
        }

        public new void DeleteFile(string path)
        {
            Logger.Write("DeleteFile");
            if (!JobObjects.Contains(path))
                throw new BackupException("There is no such file");

            JobObjects.Remove(path);
        }

        public new void Backup()
        {
            Logger.Write("Backup");
            DateTime now = DateTime.Now;
            string restorePointName = $"RestorePoint{RestorePoints.Count}_{now.Day}.{now.Month}.{now.Year}";
            var restorePoint = new RestorePoint(restorePointName, now);
            RestorePoints.Add(restorePoint);
            Repository.CreateRestorePointDir(restorePoint.Name);
            _algorithm.Backup(this, restorePoint);
            if (RestorePoints.Count > MaxPointCount)
            {
                RestorePoints.RemoveAt(RestorePoints.Count - 1);
            }
        }

        public new int CountStorages()
        {
            int result = 0;
            RestorePoints.ForEach(rp => result += rp.Files.Count);
            return result;
        }
    }
}