using StudentApi.Models;

namespace StudentApi.Services
{
    public class StudentService
    {
        List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="John",Age=20,Departmint="Computer Science"},
            new Student{Id=2,Name="Alice",Age=22,Departmint="Mathematics"},
            new Student{Id=3,Name="Bob",Age=21,Departmint="Physics"},
            new Student{Id=4,Name="Eve",Age=23,Departmint="Chemistry"},
            new Student{Id=5,Name="Charlie",Age=24,Departmint="Biology"}
        };

        public List<Student> GetAllStudents()
        {
            return students;
        }
        public Student GetStudentById(int id) { 
        return students.FirstOrDefault(s=> s.Id == id);

        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public int GetStudentsCount()
        {
                        return students.Count;
        }
 
    }
}
