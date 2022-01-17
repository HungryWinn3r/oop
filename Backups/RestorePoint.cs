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

        public DateTime DateCreation { get; }
        public List<string> Files { get; private set; } = new List<string>();
        public string Name { get; }
    }
}
