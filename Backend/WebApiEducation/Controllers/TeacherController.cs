using Microsoft.AspNetCore.Mvc;
using WebApiEducation.Application.App;
using WebApiEducation.Application.Model;
using WebApiEducation.Domain.Entity;

namespace WebApiEducation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private readonly TeacherApplication _teacherApplication;
        public TeacherController(TeacherApplication TeacherApplication)
        {
            _teacherApplication = TeacherApplication;
        }

        [HttpPost("AddTeacher")]
        public async Task<ActionResult<ResponseServiceDTO>> AddTeacher(TeacherDTO teacher)
        {
            return await _teacherApplication.AddTeacher(teacher);
        }

        [HttpDelete("DeleteTeacher")]
        public async Task<ActionResult<ResponseServiceDTO>> Deleteteacher(int id)
        {
            return await _teacherApplication.DeleteTeacher(id);
        }

        [HttpGet("GetAll")]
        public async Task<List<TeacherDTO>> GetAll()
        {
            return await _teacherApplication.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<TeacherDTO> GetById(int id)
        {
            return await _teacherApplication.GetById(id);
        }

        [HttpPut("Updateteacher")]
        public async Task<ResponseServiceDTO> Updateteacher(TeacherDTO teacher)
        {
            return await _teacherApplication.UpdateTeacher(teacher);
        }
    }
}
