using System;
using System.IO;
using System.IO.Compression;
using Backups;

namespace Backups
{
    public class PointManager
    {
        public void Decompress(string compressedFilePath, string targetFilePath)
        {
            // поток для чтения из сжатого файла
            using (var sourceStream = new FileStream(compressedFilePath, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFilePath))
                {
                    // поток разархивации
                    using (var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        compressedFilePath = null;
                    }
                }
            }
        }

        public void CheckBackupJobTime(BackupJob backup, DateTime timeWhenPointsNeedToDelete)
        {
            foreach (RestorePoint restorePoint in backup.RestorePoints)
            {
                if (restorePoint.DateCreation >= timeWhenPointsNeedToDelete)
                {
                    backup.RestorePoints.Remove(restorePoint);
                }
            }
        }

        public void Merge(RestorePoint oldRestorePoint, RestorePoint newRestorePoint)
        {
            foreach (string oldFile in oldRestorePoint.Files)
            {
                foreach (string newFile in newRestorePoint.Files)
                {
                    if (newFile == oldFile)
                    {
                        oldRestorePoint.Files.Remove(oldFile);
                    }

                    if (!newRestorePoint.Files.Contains(oldFile))
                    {
                        newRestorePoint.Files.Add(oldFile);
                    }
                }
            }
        }

        public void RestoreForOriginalLocation(RestorePoint restorePoint)
        {
            foreach (string file in restorePoint.Files)
            {
                Decompress(file, file);
            }
        }

        public void RestoreForDifferentLocation(RestorePoint restorePoint, string tragetFilePath)
        {
            foreach (string file in restorePoint.Files)
            {
                Decompress(file, tragetFilePath);
            }
        }
    }
}
