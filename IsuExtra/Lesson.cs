using System;

namespace Isu
{
    public class Lesson
    {
        public Lesson(int date, DateTime time, string teacher, int classroom, Group ognpGroup)
        {
            Date = date;
            Time = time;
            Teacher = teacher;
            Classroom = classroom;
            OgnpGroup = ognpGroup;
        }

        public Lesson(int date, DateTime time, string teacher, int classroom)
        {
            Date = date;
            Time = time;
            Teacher = teacher;
            Classroom = classroom;
        }

        public int Date { get; }

        public DateTime Time { get; }

        public string Teacher { get; }

        public int Classroom { get; }

        public Group OgnpGroup { get; }
    }
}
