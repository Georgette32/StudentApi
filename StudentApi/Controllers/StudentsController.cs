using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml.Linq;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="John",Age=20,Departmint="Computer Science"},
            new Student{Id=2,Name="Alice",Age=22,Departmint="Mathematics"},
            new Student{Id=3,Name="Bob",Age=21,Departmint="Physics"},
            new Student{Id=4,Name="Eve",Age=23,Departmint="Chemistry"},
            new Student{Id=5,Name="Charlie",Age=24,Departmint="Biology"}
        };

        [HttpGet("all")]
        public IActionResult GetAllStudents()
        {
            return Ok(students);
        }

        [HttpGet("getstudent/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return Ok(student);
        }

        [HttpGet("search")]
        public IActionResult GetStudentByName(string name) {
            var studentname = students.FirstOrDefault(s => s.Name == name);
           if (studentname == null)
            {
                return NotFound($"Student with Name = {name} not found");
            }
            return Ok(studentname);

        }
        [HttpGet("department/{department}")]
        public IActionResult GetStudentByDepartment(string department)
        {

            var studentDepartment = students.Where(s=>s.Departmint == department).ToList();
            if (!studentDepartment.Any())
            {
                return NotFound($"No students found in {department} department");
            }

            return Ok(studentDepartment);
        }

        [HttpPost]

        public IActionResult AddStudent(Student student)
        {
            students.Add(student);
            return Ok($"Student with Id = {student.Id} added successfully");
        }

        [HttpGet("count")]
        public IActionResult GetStudentCount()
        {//int count = students.Count;
            return Ok(students.Count());
           // return Ok(count);
        }
        [HttpGet("average-age")]
        public IActionResult GetAverage() { 
      
            return Ok(students.Average(s => s.Age));
        }

        [HttpGet("max-age")]
        public IActionResult GetMaxAge()
        {
           var oldestStudent = students.MaxBy(s => s.Age);
            return Ok(oldestStudent);
        }

        [HttpGet]
        public string Get()
        {
            return "Hello ASP.NET Core";
        }
        [HttpGet("welcome")]
        public string Welcome()
        {
            return "Welcome to the Student API!";
        }
        [HttpGet("{id}")]
        public string GetStudentByid(int id)
        {
            // For demonstration purposes, return the student ID
            return $"Student Id = {id}";
        }
        [HttpGet("sum")]
        public int sumnumbers(int a,int b) { 

            return a + b;
        }


    }
}
