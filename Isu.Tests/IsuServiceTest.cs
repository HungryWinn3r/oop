using Isu.Services;
using Isu.Tools;
using NUnit.Framework;
namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;
        [SetUp]
        public void Setup()
        {
            _isuService = null;
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group group = _isuService.AddGroup("M3206", 15);
            _isuService.AddStudent("Alex", group);
            Group foundedGroup = _isuService.FindGroup("M3206");
            Student foundedStudent = _isuService.FindStudent("Alex");
            Assert.Contains(foundedStudent, foundedGroup.StudentsInGroup);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group group = _isuService.AddGroup("M3202", 199191);

            Assert.Catch<IsuException>(() => 
            { 
                for (int i = 0; i < int.MaxValue; i++)
                    _isuService.AddStudent("Student", group);
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group group = _isuService.AddGroup("qwerty", 15);
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
                Group group = _isuService.AddGroup("M3206", 15);
                Group group1 = _isuService.AddGroup("M3204", 15);
                Student student = _isuService.AddStudent("Alex", group1);
                _isuService.ChangeStudentGroup(student, group);
                Student foundedStudent = _isuService.FindStudent("Alex");
                Assert.AreEqual(group.Name, foundedStudent.Group.Name);
        }
    }
} 