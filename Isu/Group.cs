using System.Collections.Generic;
using System.Text.RegularExpressions;
using Isu.Tools;

namespace Isu
{
    public class Group
    {
        private static Regex pattern = new Regex(@"\bM3[1-4](?(?=0)0[0-9]|1[0-5])\b");
        public Group(string name, int limit)
        {
            if (!pattern.IsMatch(name))
                throw new IsuException();

            Name = name;
            Limit = limit;
            StudentsInGroup = new List<Student>();
        }

        public Group(Group other)
        {
            Limit = other.Limit;
            Name = other.Name;
            Id = other.Id;
            StudentsInGroup = other.StudentsInGroup;
        }

        public List<Student> StudentsInGroup { get; }

        public string Name { get; }

        public int Id { get; }

        public int Limit { get; }
    }
}