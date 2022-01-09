using System;
using System.Collections.Generic;

namespace Backups
{
    public class BackupJob
    {
        private Algorithm _algorithm;
        private IRepository _repository;
        public BackupJob(string name, Algorithm algorithm, int maxPointCount)
        {
            Name = name;
            _algorithm = algorithm;
            _repository = algorithm.Repository;
            _repository.CreateBackupDir(name);
            MaxPointCount = maxPointCount;
        }

        public List<string> JobObjects { get; private set; } = new List<string>();
        public string Name { get; }
        public List<RestorePoint> RestorePoints { get; private set; } = new List<RestorePoint>();
        public int MaxPointCount { get; }

        public void AddFile(string path)
        {
            JobObjects.Add(path);
        }

        public void DeleteFile(string path)
        {
            if (!JobObjects.Contains(path))
                throw new BackupException("There is no such file");

            JobObjects.Remove(path);
        }

        public void Backup(BackupJob backup)
        {
            DateTime now = DateTime.Now;
            string restorePointName = $"RestorePoint{RestorePoints.Count}_{now.Day}.{now.Month}.{now.Year}";
            var restorePoint = new RestorePoint(restorePointName, now);
            RestorePoints.Add(restorePoint);
            _repository.CreateRestorePointDir(restorePoint.Name);
            _algorithm.Backup(this, restorePoint);
            if (RestorePoints.Count > backup.MaxPointCount)
            {
                RestorePoints.RemoveAt(RestorePoints.Count - 1);
            }
        }

        public int CountStorages()
        {
            int result = 0;
            RestorePoints.ForEach(rp => result += rp.Files.Count);
            return result;
        }
    }
}
