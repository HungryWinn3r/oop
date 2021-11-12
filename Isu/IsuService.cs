using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;

namespace Isu
{
    public class IsuService : IIsuService
    {
        public static readonly List<Group> AllGroups = new List<Group>();
        public static readonly List<Student> AllStudents = new List<Student>();

        public static bool CheckCourse(string groupName, CourseNumber courseNumber)
        {
            string course = groupName;
            if ((int)course[2] == (int)courseNumber)
                return true;
            return false;
        }

        public Student AddStudent(string name, Group group)
        {
            var newStudent = new Student(name, IdMaker.MakeId(), group);
            group.StudentsInGroup.Add(newStudent);
            AllStudents.Add(newStudent);
            return newStudent;
        }

        public Group AddGroup(string name, int limit)
        {
            var newGroup = new Group(name, limit);
            AllGroups.Add(newGroup);
            return newGroup;
        }

        public Group FindGroup(string name)
        {
            Group group = AllGroups.Find(group => group.Name == name);
            return group;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groupsCourse = new List<Group>();
            groupsCourse.AddRange(AllGroups.FindAll(group => CheckCourse(group.Name, courseNumber)));
            return groupsCourse;
        }

        public List<Student> FindStudents(string groupName)
        {
            Group group = FindGroup(groupName);
            if (group == null)
                throw new IsuException();

            return group.StudentsInGroup;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var courseStudents = new List<Student>();
            courseStudents.AddRange(AllStudents.FindAll(student => CheckCourse(student.Group.Name, courseNumber)));
            return courseStudents;
        }

        public Student GetStudent(int id)
        {
            Student student = AllStudents.Find(student => student.Id == id);
            return student;
        }

        public Student FindStudent(string name)
        {
            Student student = AllStudents.Find(student => student.Name == name);
            return student;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            var newStudent = new Student(student.Name, student.Id, newGroup);
            AllStudents.Add(newStudent);
            AllStudents.Remove(student);
            student.Group.StudentsInGroup.Remove(student);
            newGroup.StudentsInGroup.Add(newStudent);
        }
    }
}