using Microsoft.AspNetCore.Mvc;
using WebApiEducation.Application.App;
using WebApiEducation.Application.Model;
using WebApiEducation.Domain.Entity;

namespace WebApiEducation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private readonly NoteApplication _noteApplication;

        public NoteController(NoteApplication noteApplication)
        {
            _noteApplication = noteApplication;
        }

        [HttpPost("AddNote")]
        public async Task<ActionResult<ResponseServiceDTO>> AddNote(NoteDTO note)
        {
            return await _noteApplication.AddNote(note);
        }

        [HttpDelete("DeleteNote")]
        public async Task<ActionResult<ResponseServiceDTO>> DeleteNote(int id)
        {
            return await _noteApplication.DeleteNote(id);
        }
        [HttpGet("GetAll")]
        public async Task<List<NoteDTO>> GetAll()
        {
            return await _noteApplication.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<NoteDTO> GetById(int id)
        {
            return await _noteApplication.GetById(id);
        }

        [HttpPut("UpdateNote")]
        public async Task<ResponseServiceDTO> UpdateNote(NoteDTO note)
        {
            return await _noteApplication.UpdateNote(note);
        }
    }
}
