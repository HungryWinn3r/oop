using System.Collections.Generic;

namespace Backups
{
    public interface IRepository
    {
        string CompressFile(string sourceFile, string restorePointDirName);
        void CreateBackupDir(string backupName);
        void CreateRestorePointDir(string restorePointName);
        string CreateArchive(List<string> sourceFiles, string restorePointDirName);
    }
}
