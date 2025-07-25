using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Interface;
using WebApiEducation.Domain.Model;
using WebApiEducation.Infrastructure.Persistence;

namespace WebApiEducation.Infrastructure.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly AudisoftEducationContext _context;
        private readonly ILogWebApiRepository _logWeb;

        public NoteRepository(AudisoftEducationContext context, ILogWebApiRepository logWeb)
        {
            _context = context;
            _logWeb = logWeb;
        }

        public async Task<ResponseService> AddNote(Note note)
        {
            try
            {
                Note exist = await _context.Note.FindAsync(note.Id);
                if (exist != null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "AddNote", Message = "Ya existe esta nota no se puede agregar" });
                    return new ResponseService { Message = "Ya existe esta nota no se puede agregar", Success = false, Tipo = "Warning" };
                }

                Student student = await _context.Student.FindAsync(note.idStudent);
                if (student == null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "AddNote", Message = "No se puede agregar nota si no existe el estudiante" });
                    return new ResponseService { Message = "No se puede agregar nota si no existe el estudiante", Success = false, Tipo = "Warning" };
                }

                Teacher teacher = await _context.Teacher.FindAsync(note.idTeacher);
                if (teacher == null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "AddNote", Message = "No se puede agregar nota si no existe el profesor" });
                    return new ResponseService { Message = "No se puede agregar nota si no existe el profesor", Success = false, Tipo = "Warning" };
                }

                _context.Note.Add(note);
                await _context.SaveChangesAsync();
                return new ResponseService { Message = "Se ha agregado ua nota", Success = true, Tipo = "Execution" };
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "AddNote", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo = "Error" };
            }
        }

        public async Task<ResponseService> DeleteNote(int id)
        {
            try
            {
                Note exist = await _context.Note.FindAsync(id);
                if (exist == null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "DeleteNote", Message = "No se ha encontrado la nota a borrar" });
                    return new ResponseService { Message = "No se ha encontrado la nota a borrar", Success = false, Tipo = "Warning" };
                }

                Teacher teacherNota = await _context.Teacher.Where(x => x.Id == exist.idTeacher).FirstOrDefaultAsync();
                if (teacherNota != null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "DeleteTeacher", Message = "No se puede eliminar la nota por que esta asociada aun profesor" });
                    return new ResponseService { Message = "No se puede eliminar la nota por que esta asociada aun profesor", Success = false, Tipo = "warning" };
                }

                Student studentNota = await _context.Student.Where(x => x.Id == exist.idStudent).FirstOrDefaultAsync();
                if (studentNota != null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "DeleteTeacher", Message = "No se puede eliminar la nota por que esta asociada aun estudiante" });
                    return new ResponseService { Message = "No se puede eliminar la nota por que esta asociada aun estudiante", Success = false, Tipo = "warning" };
                }

                _context.Note.Remove(exist);
                await _context.SaveChangesAsync();
                return new ResponseService { Message = "Ha sido borrado la nota", Success = true, Tipo = "Execution" };
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "DeleteNote", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo = "Error" };
            }
        }

        public async Task<List<Note>> GetAll()
        {
            List<Note> note = new List<Note>();
            try
            {
                note = await _context.Note.ToListAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "GetAll", Message = ex.Message });
                return null;
            }
            return note;
        }

        public async Task<Note> GetById(int id)
        {
            Note note = null;
            try
            {
                note = await _context.Note.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "GetById", Message = ex.Message });
                return null;
            }
            return note;

        }

        public async Task<ResponseService> UpdateNote(Note note)
        {
            try
            {
                Note exist = await _context.Note.FindAsync(note.Id);
                if (exist == null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "UpdateNote", Message = "No se ha encontrado la nota a actualizar" });
                    return new ResponseService { Message = "No se ha encontrado la nota a actualizar", Success = false, Tipo = "Warning" };
                }
                exist.Name = note.Name;
                exist.idStudent = note.idStudent;
                exist.idTeacher = note.idTeacher;
                exist.Value = note.Value;

                _context.Note.Update(exist);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "UpdateNote", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo = "Error" };
            }
            return new ResponseService { Message = "Se ha actualizado la nota", Success = true, Tipo = "Execution" };
        }

    }
}
