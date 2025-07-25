using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Model;

namespace WebApiEducation.Domain.Interface
{
    public interface INoteRepository
    {
       Task<List<Note>> GetAll();
       Task<Note> GetById(int id);
       Task<ResponseService> AddNote(Note note);
       Task<ResponseService> DeleteNote(int id);
       Task<ResponseService> UpdateNote(Note note);
    }
}
