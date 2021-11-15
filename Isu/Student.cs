using Isu.Tools;

namespace Isu
{
    public class Student
    {
        public Student(string name, int id, Group group, string fac)
        {
            if (group.StudentsInGroup.Count >= group.Limit)
                throw new IsuException("Group is full");
            Name = name;
            Id = id;
            Group = group;
            Fac = fac;
            Timetable = new int[6, 8];
        }

        public int[,] Timetable { get; }

        public string Fac { get; }

        public string Name { get; }

        public int Id { get; }

        public Group Group { get; }
    }
}
