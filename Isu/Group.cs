using System.Collections.Generic;

namespace Isu
{
    public class Group
    {
        public Group(string name, int limit)
        {
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