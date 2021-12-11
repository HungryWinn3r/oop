using System;
using System.Collections.Generic;
using System.Text;

namespace Backups
{
    public class RestorePoint
    {
        public RestorePoint(DateTime dateTime)
        {
            CreatedTime = dateTime;
            Id = IdMaker.MakeId();
            ListOfFiles = new List<int>();
        }

        public DateTime CreatedTime { get; }

        public int Id { get; }

        public List<int> ListOfFiles { get; }
    }
}
