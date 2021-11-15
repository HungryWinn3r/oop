using System.Collections.Generic;

namespace Isu
{
    public class Lesson
    {
        public Lesson(int date, int time, string teacher, int classroom, Group ognpGroup)
        {
            Date = date;
            Time = time;
            Teacher = teacher;
            Classroom = classroom;
            OgnpGroup = ognpGroup;
            StudentsAtLesson = new List<Student>();
        }

        public Lesson(int date, int time, string teacher, int classroom)
        {
            Date = date;
            Time = time;
            Teacher = teacher;
            Classroom = classroom;
            StudentsAtLesson = new List<Student>();
        }

        public int Date { get; }

        public int Time { get; }

        public string Teacher { get; }

        public int Classroom { get; }

        public Group OgnpGroup { get; }

        public List<Student> StudentsAtLesson { get; }
    }
}
