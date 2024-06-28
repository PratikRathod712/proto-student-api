using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTestAPI.Models;
using System.Xml.Linq;

namespace StudentTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _dbContext;
        public StudentController(StudentContext context)
        {
            _dbContext = context;
        }
/*        private static List<Student> students = new List<Student>
            {
                new Student {
                    Id = 1,
                    Name = "Student1",
                    Email="student1@gmail.com"
                },
                new Student {
                    Id = 2,
                    Name = "Student2",
                    Email="student2@gmail.com"
                },
                new Student {
                    Id = 3,
                    Name = "Student3",
                    Email="student3@gmail.com"
                }
            };*/


        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {   
         
            return Ok(await _dbContext.Students.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x=> x.Id == id);
            if(student == null)
            {
                return BadRequest("Student not found...");
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Students.ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student request)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (student == null)
            {
                return BadRequest("Student not found...");
            }
            student.Name = request.Name;
            student.Email = request.Email;
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return BadRequest("Student not found...");
            }
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Students.ToListAsync());
        }

    }
}
