using System;
using System.Collections.Generic;
using IsuExtra.Services;

namespace Isu
{
    public class IsuExtraService : IIsuExtra
    {
        public static readonly List<Student> AllStudentsWithoutOgnp = new List<Student>(IsuService.AllStudents);
        public static readonly List<Stream> AllStreams = new List<Stream>();

        public Lesson AddLesson(int date, int time, string teacher, int classroom, Group ognpGroup)
        {
            var newLesson = new Lesson(date, time, teacher, classroom, ognpGroup);
            return newLesson;
        }

        public Lesson AddLesson(int date, int time, string teacher, int classroom)
        {
            var newLesson = new Lesson(date, time, teacher, classroom);
            return newLesson;
        }

        public Ognp AddOgnp(string name, string fac)
        {
            var newOgnp = new Ognp(name, fac);
            return newOgnp;
        }

        public Stream AddStream(string name, int limit)
        {
            var newStream = new Stream(name, limit);
            return newStream;
        }

        public void AddStreamToOgnp(Ognp ognp, Stream stream)
        {
            ognp.StreamsAtOgnp.Add(stream);
        }

        public void AddStudentToLesson(Lesson lesson, Student student)
        {
            lesson.StudentsAtLesson.Add(student);
            if (student.Timetable[lesson.Date, lesson.Time] != 1)
            {
                student.Timetable[lesson.Date, lesson.Time] = 1;
            }
            else if (student.Timetable[lesson.Date, lesson.Time] == 1)
            {
                throw new Exception("bad time");
            }
        }

        public void AddStudentToOgnp(Ognp ognp, Stream stream, Student student)
        {
            if (ognp.Fac == student.Fac)
                throw new Exception("same fac");

            if (stream.StudentsAtStream.Count < stream.Limit)
            {
                stream.StudentsAtStream.Add(student);
                AllStudentsWithoutOgnp.Remove(student);
            }
            else
            {
                throw new Exception("full stream");
            }
        }

        public void RemoveStudentFromOgnp(Stream stream, Student student)
        {
            AllStudentsWithoutOgnp.Add(student);
            stream.StudentsAtStream.Remove(student);
        }

        public List<Stream> FindStreams(CourseNumber courseNumber)
        {
            return AllStreams.FindAll(stream => IsuService.CheckCourse(stream.Name, courseNumber));
        }

        public List<Student> FindStudents(string groupName)
        {
            Group group = IsuService.AllGroups.Find(group => group.Name == groupName);
            if (group == null)
                throw new Exception("not found");

            return group.StudentsInGroup;
        }

        public List<Student> FindStudentsWithoutOgnp()
        {
            return AllStudentsWithoutOgnp;
        }
    }
}
