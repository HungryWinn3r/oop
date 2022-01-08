namespace Backups
{
    public abstract class Algorithm
    {
        public Algorithm(IRepository repository)
        {
            Repository = repository;
        }

        public IRepository Repository { get; private set; }
        public abstract void Backup(BackupJob backupJob, RestorePoint restorePoint);
    }
}
