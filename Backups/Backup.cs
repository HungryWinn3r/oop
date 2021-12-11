using System;
using System.Collections.Generic;
using System.Text;

namespace Backups
{
    public class Backup
    {
        public List<string> Files { get; } = new List<string>();
        public List<RestorePoint> RestorePoints { get; } = new List<RestorePoint>();
    }
}
