using System.Collections.Generic;
using System.IO;

namespace Backups
{
    public class TestRepository : IRepository
    {
        public TestRepository() { }

        public List<string> RestorePoints { get; private set; } = new List<string>();

        public string Storage { get; private set; }
        public void CreateBackupDir(string backupName)
        {
            Storage = backupName;
        }

        public void CreateRestorePointDir(string restorePointName)
        {
            RestorePoints.Add(restorePointName);
        }

        public string CompressFile(string sourceFile, string restorePointDirName)
        {
            var fileInfo = new FileInfo(sourceFile);
            return Path.ChangeExtension(Storage + $@"\{restorePointDirName}\{fileInfo.Name}", "zip");
        }

        public string CreateArchive(List<string> sourceFiles, string restorePointDirName)
        {
            string zipFile = Storage + $@"\{restorePointDirName}\copies.zip";
            return zipFile;
        }
    }
}
