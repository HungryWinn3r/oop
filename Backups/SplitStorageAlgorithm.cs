using System.Collections.Generic;

namespace Backups
{
    public class SplitStorageAlgorithm : Algorithm
    {
        public SplitStorageAlgorithm(IRepository repository)
            : base(repository) { }

        public override void Backup(BackupJob backupJob, RestorePoint restorePoint)
        {
            var sourceFiles = new List<string>(backupJob.JobObjects);
            foreach (string sourceFile in sourceFiles)
            {
                string compressedFile = Repository.CompressFile(sourceFile, restorePoint.Name);
                restorePoint.Files.Add(compressedFile);
            }
        }
    }
}
