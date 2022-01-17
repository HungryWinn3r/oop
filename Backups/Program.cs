using System;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var factory = new SimpleAlgorithmFactory(new LocalFileRepository("C:"));
            Algorithm algorithm;

            algorithm = factory.CreateAlgorithm(AlgorithmType.SINGLE);

            var backupJob = new BackupJob("Backup2022_2", algorithm);
            backupJob.AddFile("C:\\MyPhoto\\photo1.txt");
            backupJob.AddFile("C:\\MyVideo\\video1.txt");
            backupJob.Backup();
            backupJob.DeleteFile("C:\\MyPhoto\\photo1.txt");
            backupJob.Backup();
            Console.WriteLine("Ready!");
        }
    }
}
