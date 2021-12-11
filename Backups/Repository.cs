using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Backups
{
    public class Repository
    {
        public void AddBackupDir(string path)
        {
            var newDirectory = new DirectoryInfo(path);
            newDirectory.Create();
        }

        public void AddRestorePointDir(string path)
        {
            var newDirectory = new DirectoryInfo(path);
            newDirectory.Create();
        }

        public string Compress(string file, string path)
        {
            using var sourceStream = new FileStream(file, FileMode.OpenOrCreate);

            using FileStream targetStream = File.Create(path);

            using var compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            sourceStream.CopyTo(compressionStream);
            return path;
        }

        public string Decompress(string compressedFile, string targetFile)
        {
            using var sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate);

            using FileStream targetStream = File.Create(targetFile);

            using var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress);
            decompressionStream.CopyTo(targetStream);
            return targetFile;
        }

        public string Archive(List<string> files, string path)
        {
            foreach (string file in files)
            {

            }
        }
    }
}
