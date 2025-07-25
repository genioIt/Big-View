using Microsoft.AspNetCore.Mvc;
using WebApiEducation.Application.App;
using WebApiEducation.Application.Model;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Model;

namespace WebApiEducation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentApplication _studentApplication;
        public StudentController(StudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<ResponseServiceDTO>> AddStudent(StudentDTO student)
        {
            return await _studentApplication.AddStudent(student);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<ResponseServiceDTO>> DeleteStudent(int id)
        {
            return await _studentApplication.DeleteStudent(id);
        }

        [HttpGet("GetAll")]
        public async Task<List<StudentDTO>> GetAll() {
            return await _studentApplication.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<StudentDTO> GetById(int id)
        {
            return await _studentApplication.GetById(id);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ResponseServiceDTO> UpdateStudent(StudentDTO student)
        {
             return await _studentApplication.UpdateStudent(student);
        }
    }
}
