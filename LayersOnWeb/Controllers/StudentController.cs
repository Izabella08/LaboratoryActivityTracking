using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }


        [HttpGet("GetAllStudents")]
        [Authorize(Roles = "Teacher")]
        public IEnumerable<Student> Get()
        {
            var result = new List<Student>();
            foreach (var student in studentService.GetAllStudents())
            {
                result.Add(new Student { Id = student.Id, Email = student.Email, Name = student.Name, Group = student.Group, Hobby = student.Hobby, FinalGrade = student.FinalGrade, Passed = student.Passed });
            }
            return result;
        }


        [HttpPost("AddStudent")]
        [Authorize(Roles = "Teacher")]
        public void Post(Student student)
        {
            studentService.AddStudentModel(new StudentModel { Email = student.Email, Name = student.Name, Group = student.Group, Hobby = student.Hobby});
        }


        [HttpDelete("DeleteStudentById")]
        [Authorize(Roles = "Teacher")]
        public bool DeleteStudentById(Guid studentId)
        {
            try
            {
                studentService.DeleteStudentModelById(studentId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpGet("GetStudentById")]
        [Authorize(Roles = "Teacher")]
        public Object GetStudentById(Guid Id)
        {
            try
            {
                var data = studentService.GetStudentModelById(Id);
                if (data == null) return NotFound();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpPut("UpdateStudent")]
        [Authorize(Roles = "Teacher")]
        public bool UpdateStudent(StudentModel student)
        {
            try
            {
                studentService.UpdateStudentModel(student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
