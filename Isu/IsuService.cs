using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;

namespace Isu
{
    public class IsuService : IIsuService
    {
        private readonly List<Group> allGroups = new List<Group>();
        private readonly List<Student> allStudents = new List<Student>();

        public bool CheckCourse(string groupName, CourseNumber courseNumber)
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
            allStudents.Add(newStudent);
            return newStudent;
        }

        public Group AddGroup(string name, int limit)
        {
            var newGroup = new Group(name, limit);
            allGroups.Add(newGroup);
            return newGroup;
        }

        public Group FindGroup(string name)
        {
            return allGroups.Find(group => group.Name == name);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return allGroups.FindAll(group => CheckCourse(group.Name, courseNumber));
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
            return allStudents.FindAll(student => CheckCourse(student.Group.Name, courseNumber));
        }

        public Student GetStudent(int id)
        {
            return allStudents.Find(student => student.Id == id);
        }

        public Student FindStudent(string name)
        {
            return allStudents.Find(student => student.Name == name);
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            var newStudent = new Student(student.Name, student.Id, newGroup);
            allStudents.Add(newStudent);
            allStudents.Remove(student);
            student.Group.StudentsInGroup.Remove(student);
            newGroup.StudentsInGroup.Add(newStudent);
        }
    }
}