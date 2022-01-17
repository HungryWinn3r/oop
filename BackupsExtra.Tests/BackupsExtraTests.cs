using Backups;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupsExtraTests
    {
        private ExtraBackupJob _backupJob;
        private TestRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new TestRepository();
            _backupJob = new ExtraBackupJob("test", new SplitStorageAlgorithm(_repository), 10, new TestLogger());
        }

        [Test]
        public void SaverTest()
        {
            string file123 = @"./123.txt";
            string fileqwe = @"./qwe.docx";
            string fileabc = @"./abc.txt";
            _backupJob.AddFile(file123);
            _backupJob.Backup();
            _backupJob.AddFile(fileqwe);
            _backupJob.Backup();
            _backupJob.AddFile(fileabc);
            _backupJob.Backup();
            string save = TestLoader.Save(_backupJob);
            BackupJob newBackupJob = TestLoader.Load(save);
            Assert.That(_backupJob.Name == newBackupJob.Name);
            Assert.That(_backupJob.JobObjects.Count == newBackupJob.JobObjects.Count);
            Assert.That(_backupJob.RestorePoints.Count == newBackupJob.RestorePoints.Count);
            for (int i = 0; i < _backupJob.RestorePoints.Count; i++)
            {
                Assert.That(_backupJob.RestorePoints[i].Files.Count == newBackupJob.RestorePoints[i].Files.Count);
            }
        }
    }
}