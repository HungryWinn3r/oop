using System;
using System.Collections.Generic;

namespace Backups
{
    public class RestorePoint
    {
        public RestorePoint(string name, DateTime dateCreation)
        {
            DateCreation = dateCreation;
            Name = name;
        }

        public RestorePoint(string name, DateTime dateCreation, List<string> files)
        {
            DateCreation = dateCreation;
            Name = name;
            Files = files;
        }

        public DateTime DateCreation { get; }
        public List<string> Files { get; set; } = new List<string>();
        public string Name { get; }
    }
}
