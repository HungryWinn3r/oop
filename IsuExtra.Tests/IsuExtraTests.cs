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
            isuService = new IsuService();
            isuExtra = new IsuExtraService();
        }

        [Test]
        public void AddStudentToOgnp_StreamContainsStudent()
        {
            Group group = isuService.AddGroup("B12", 30);
            Student student = isuService.AddStudent("StudentName", group, "btins");
            Stream stream = isuExtra.AddStream("b13", 200);
            Ognp ognp = isuExtra.AddOgnp("FI", "tint");
            isuExtra.AddStreamToOgnp(ognp, stream);
            isuExtra.AddStudentToOgnp(ognp, stream, student);
            Assert.Contains(student, stream.StudentsAtStream);
        }

        [Test]
        public void StudentAndOgnpSameFac_ThrowExeption()
        {
            Group group = isuService.AddGroup("B12", 30);
            Student student = isuService.AddStudent("StudentName", group, "tint");
            Stream stream = isuExtra.AddStream("b13", 200);
            Ognp ognp = isuExtra.AddOgnp("FI", "tint");
            isuExtra.AddStreamToOgnp(ognp, stream);
            Assert.Catch<Exception>(() =>
            {
                isuExtra.AddStudentToOgnp(ognp, stream, student);
            });
        }
    }
}
