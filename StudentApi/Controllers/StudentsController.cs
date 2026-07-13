using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;
        private readonly MessageService _messageService;
        private readonly IConfiguration _configuration;
        public StudentsController(StudentService service, MessageService messageService, IConfiguration configuration)
        {
            _service = service;
            _messageService = messageService;
            _configuration = configuration;
        }

        [HttpGet("app - info")]
        public IActionResult GetAppInfo() {
            var appname = _configuration["AppSettings:AppName"];
            var developer = _configuration["AppSettings:Developer"];
            return Ok($"{appname}/nDeveloped By: {developer}");



        }
        [HttpGet("all")]
        public IActionResult GetAllStudents()
        {
            return Ok(_service.GetAllStudents());
        }

        [HttpGet("getstudent/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _service.GetStudentById(id);
            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return Ok(student);
        }

        [HttpGet("search")]
        public IActionResult GetStudentByName(string name) {
            var studentname = _service.GetAllStudents().FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (studentname == null)
            {
                return NotFound($"Student with Name = {name} not found");
            }
            return Ok(studentname);

        }
        [HttpGet("department/{department}")]
       /* public IActionResult GetStudentByDepartment(string department)
        {

            var studentDepartment = students.Where(s=>s.Departmint == department).ToList();
            if (!studentDepartment.Any())
            {
                return NotFound($"No students found in {department} department");
            }

            return Ok(studentDepartment);
        }*/

        [HttpPost]

        public IActionResult AddStudent(Student student)
        {
            _service.AddStudent(student);
            return Ok($"Student with Id = {student.Id} added successfully");
        }

        [HttpGet("count")]
        public IActionResult GetStudentCount()
        {//int count = students.Count;
            return Ok(_service.GetStudentsCount());
           // return Ok(count);
        }
      /*  [HttpGet("average-age")]
        public IActionResult GetAverage() { 
      
            return Ok(students.Average(s => s.Age));
        }

        [HttpGet("max-age")]
        public IActionResult GetMaxAge()
        {
           var oldestStudent = students.MaxBy(s => s.Age);
            return Ok(oldestStudent);
        }*/

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
