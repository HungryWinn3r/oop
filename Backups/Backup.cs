using System;
using System.Collections.Generic;
using System.Text;

namespace Backups
{
    public class Backup
    {
        public List<string> Files { get; } = new List<string>();
        public List<RestorePoint> RestorePoints { get; } = new List<RestorePoint>();

        public void AddFile(string name)
        {
            Files.Add(name);
        }

        public void DeleteFile(string name)
        {
            Files.Remove(name);
        }

        public void Backup()
        {
            var rePoint = new RestorePoint();

        }
    }
}
