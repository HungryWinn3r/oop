using System.Collections.Generic;
using System.IO;

namespace Backups
{
    public class TestRepository : IRepository
    {
        private string _pathToBackup;
        public TestRepository() { }

        public List<string> RestorePoints { get; private set; } = new List<string>();
        public void CreateBackupDir(string backupName)
        {
            _pathToBackup = backupName;
        }

        public void CreateRestorePointDir(string restorePointName)
        {
            RestorePoints.Add(restorePointName);
        }

        public string CompressFile(string sourceFile, string restorePointDirName)
        {
            var fileInfo = new FileInfo(sourceFile);
            return Path.ChangeExtension(_pathToBackup + $@"\{restorePointDirName}\{fileInfo.Name}", "zip");
        }

        public string CreateArchive(List<string> sourceFiles, string restorePointDirName)
        {
            string zipFile = _pathToBackup + $@"\{restorePointDirName}\copies.zip";
            return zipFile;
        }
    }
}
