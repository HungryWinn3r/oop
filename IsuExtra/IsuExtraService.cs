using System;
using System.Collections.Generic;
using IsuExtra.Services;

namespace Isu
{
    public class IsuExtraService : IIsuExtra
    {
        public static readonly List<Student> AllStudentsWithoutOgnp = new List<Student>(IsuService.AllStudents);
        public static readonly List<Stream> AllStreams = new List<Stream>();

        public Lesson AddLesson(int date, DateTime time, string teacher, int classroom, Group ognpGroup)
        {
            return new Lesson(date, time, teacher, classroom, ognpGroup);
        }

        public Lesson AddLesson(int date, DateTime time, string teacher, int classroom)
        {
            return new Lesson(date, time, teacher, classroom);
        }

        public Ognp AddOgnp(string name, string faculty)
        {
            return new Ognp(name, faculty);
        }

        public Stream AddStream(string name, int limit)
        {
            return new Stream(name, limit);
        }

        public void AddStreamToOgnp(Ognp ognp, Stream stream)
        {
            ognp.StreamsAtOgnp.Add(stream);
        }

        public void AddStudentToLessons(Student student, List<Lesson> lessons)
        {
            foreach (Lesson lesson in lessons)
            {
                foreach (Lesson lesson1 in lessons)
                {
                    if (lesson.Time == lesson1.Time)
                    {
                        throw new Exception("bad time!");
                    }
                }
            }
        }

        public void AddStudentToOgnp(Ognp ognp, Stream stream, Student student)
        {
            if (ognp.Faculty == student.Faculty)
                throw new Exception("same faculty");

            if (student.OgnpCount == 2)
            {
                throw new Exception("already two ognp chosen");
            }

            if (stream.StudentsAtStream.Count < stream.Limit)
            {
                stream.StudentsAtStream.Add(student);
                AllStudentsWithoutOgnp.Remove(student);
                student.OgnpCount += 1;
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
            student.OgnpCount -= 1;
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
