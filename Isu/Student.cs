using Isu.Tools;

namespace Isu
{
    public class Student
    {
        public Student(string name, Group group, string faculty)
        {
            if (group.StudentsInGroup.Count >= group.Limit)
                throw new IsuException("Group is full");
            Name = name;
            Id = IdMaker.MakeId();
            Group = group;
            Faculty = faculty;
            OgnpCount = 0;
        }

        public int OgnpCount { get; set; }

        public string Faculty { get; }

        public string Name { get; }

        public int Id { get; }

        public Group Group { get; }
    }
}
