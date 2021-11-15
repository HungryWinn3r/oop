using System;
using NUnit.Framework;
using Isu.Services;
using IsuExtra.Services;
using Isu;

namespace IsuExtra.Tests
{
    public class IsuExtraTests
    {
        private IIsuService isuService;
        private IIsuExtra isuExtra;

        [SetUp]
        public void Setup()
        {
            isuService = null;
            isuService = new IsuService();
            isuExtra = null;
            isuExtra = new IsuExtraService();
        }

        [Test]
        public void AddStudentToOgnp_StreamContainsStudent()
        {
            Group group = isuService.AddGroup("B123", 30);
            Student student = isuService.AddStudent("StudentName", group, "btins");
            Stream stream = isuExtra.AddStream("b123/1", 200);
            Ognp ognp = isuExtra.AddOgnp("FI", "tint");
            isuExtra.AddStreamToOgnp(ognp, stream);
            isuExtra.AddStudentToOgnp(ognp, stream, student);
            Assert.Contains(student, stream.StudentsAtStream);
        }

        [Test]
        public void StudentAndOgnpSameFac_ThrowExeption()
        {
            Group group = isuService.AddGroup("B123", 30);
            Student student = isuService.AddStudent("StudentName", group, "tint");
            Stream stream = isuExtra.AddStream("b123/1", 200);
            Ognp ognp = isuExtra.AddOgnp("FI", "tint");
            isuExtra.AddStreamToOgnp(ognp, stream);
            Assert.Catch<Exception>(() =>
            {
                isuExtra.AddStudentToOgnp(ognp, stream, student);
            });
        }

        [Test]
        public void LessonsAtTheSameTime_ThrowExeption()
        {
            Ognp ognp = isuExtra.AddOgnp("name", "facname");
            Group group = isuService.AddGroup("groupname", 10);
            Lesson lesson = isuExtra.AddLesson(1, 1, "teacher", 555);
            Lesson ognpLesson = isuExtra.AddLesson(1, 1, "teacher", 123, group);
            Student student = isuService.AddStudent("student", group, "nameFac");
            isuExtra.AddStudentToLesson(ognpLesson, student);
            Assert.Catch<Exception>(() =>
            {
                isuExtra.AddStudentToLesson(lesson, student);
            });
        }
    }
}
