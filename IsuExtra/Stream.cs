using System.Collections.Generic;

namespace Isu
{
    public class Stream
    {
        public Stream(string name, int limit)
        {
            Name = name;
            Limit = limit;
            LessonsAtStream = new List<Lesson>();
            StudentsAtStream = new List<Student>();
        }

        public Group Group { get; }
        public int Limit { get; }
        public string Name { get; }
        public List<Lesson> LessonsAtStream { get; }
        public List<Student> StudentsAtStream { get; }
    }
}
