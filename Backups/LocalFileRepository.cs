using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups
{
    public class LocalFileRepository : IRepository
    {
        private string _storage;
        private string _pathToBackup;

        public LocalFileRepository(string storage)
        {
            if (!Directory.Exists(storage))
                throw new BackupException("There is no such storage");
            _storage = storage;
        }

        public void CreateBackupDir(string backupName)
        {
            _pathToBackup = _storage + $@"\{backupName}";
            var directoryInfo = new DirectoryInfo(_pathToBackup);
            if (directoryInfo.Exists)
                throw new BackupException("This backup directory already created");
            directoryInfo.Create();
        }

        public void CreateRestorePointDir(string restorePointName)
        {
            string pathToRestorePoint = _pathToBackup + $@"\{restorePointName}";
            var directoryInfo = new DirectoryInfo(pathToRestorePoint);
            directoryInfo.Create();
        }

        public string CompressFile(string sourceFile, string restorePointDirName)
        {
            var fileInfo = new FileInfo(sourceFile);
            string compressedFile = Path.ChangeExtension(_pathToBackup + $@"\{restorePointDirName}\{fileInfo.Name}", "zip");
            using (var sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    using (var compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }

            return compressedFile;
        }

        public string CreateArchive(List<string> sourceFiles, string restorePointDirName)
        {
            string tmpDirPath = _pathToBackup + @"\tmp";
            DirectoryInfo dirInfo = Directory.CreateDirectory(tmpDirPath);

            foreach (string sourceFile in sourceFiles)
            {
                var fileInfo = new FileInfo(sourceFile);
                File.Copy(sourceFile, tmpDirPath + $@"\{fileInfo.Name}");
            }

            string zipFile = _pathToBackup + $@"\{restorePointDirName}\copies.zip";
            ZipFile.CreateFromDirectory(tmpDirPath, zipFile);

            dirInfo.Delete(true);

            return zipFile;
        }
    }
}
