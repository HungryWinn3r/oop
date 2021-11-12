using Isu.Tools;

namespace Isu
{
    public class Student
    {
        public Student(string name, int id, Group group)
        {
            if (group.StudentsInGroup.Count >= group.Limit)
                throw new IsuException("Group is full");
            Name = name;
            Id = id;
            Group = group;
        }

        public string Name { get; }

        public int Id { get; }

        public Group Group { get; }
    }
}
