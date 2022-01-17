using System.Collections.Generic;

namespace Backups
{
    public class SingleStorageAlgorithm : Algorithm
    {
        public SingleStorageAlgorithm(IRepository repository)
            : base(repository) { }

        public override void Backup(BackupJob backupJob, RestorePoint restorePoint)
        {
            var sourceFiles = new List<string>(backupJob.JobObjects);
            string zipFile = Repository.CreateArchive(sourceFiles, restorePoint.Name);
            restorePoint.Files.Add(zipFile);
        }
    }
}
