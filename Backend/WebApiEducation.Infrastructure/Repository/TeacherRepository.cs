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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AudisoftEducationContext _context;
        private readonly ILogWebApiRepository _logWeb;

        public TeacherRepository(AudisoftEducationContext context, ILogWebApiRepository logWeb)
        {
            _context = context;
            _logWeb = logWeb;
        }

        public async Task<ResponseService> AddTeacher(Teacher teacher)
        {
            try
            {
                Teacher exist = await _context.Teacher.FindAsync(teacher.Id);
                if (exist != null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "AddStudent", Message = "Ya existe este profesor no se puede agregar"});
                    return new ResponseService { Message = "Ya existe este profesor no se puede agregar", Success = false,Tipo="Warning" };
                }

                _context.Teacher.Add(teacher);
                await _context.SaveChangesAsync();
                return new ResponseService { Message = "Se ha adicionado un nuevo Profesor", Success = true, Tipo = "Execution" };
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "AddTeacher", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo="Error" };
            }
        }

        public async Task<ResponseService> DeleteTeacher(int id)
        {
            try
            {

                Teacher exist = await _context.Teacher.FindAsync(id);
                if (exist == null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "DeleteTeacher", Message = "Ya existe este profesor no se puede agregar" });
                    return new ResponseService { Message = "No se ha encontrado el profesor a borrar", Success = false,Tipo = "Warning" };
                }

                Note teacherNota = await _context.Note.Where(x => x.idTeacher == exist.Id).FirstOrDefaultAsync();
                if (teacherNota != null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "DeleteTeacher", Message = "No se puede eliminar el profesor por que esta asignado en una nota" });
                    return new ResponseService { Message = "No se puede eliminar el profesor por que esta asignado en una nota", Success = false, Tipo = "warning" };
                }

                _context.Teacher.Remove(exist);
                await _context.SaveChangesAsync();
                return new ResponseService { Message = "Ha sido borrado el profesor", Success = true, Tipo = "Execution" };
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "DeleteTeacher", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo = "Error" };
            }
        }

        public async Task<List<Teacher>> GetAll()
        {
            List<Teacher> teacher = new List<Teacher>();
            try
            {
                teacher = await _context.Teacher.ToListAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "GetAll", Message = ex.Message, });
                return null;
            }
            return teacher;
        }



        public async Task<Teacher> GetById(int id)
        {
            Teacher teacher = null;
            try
            {
                teacher = await _context.Teacher.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "GetById", Message = ex.Message });
                return null;
            }
            return teacher;

        }

        public async Task<ResponseService> UpdateTeacher(Teacher teacher)
        {
            try
            {
                Teacher exist = await _context.Teacher.FindAsync(teacher.Id);
                if (exist == null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "UpdateTeacher", Message = "No se ha encontrado el profesor a Actualizar" });
                    return new ResponseService { Message = "No se ha encontrado el profesor a Actualizar", Success = false, Tipo = "Warning" };
                }
                exist.Names = teacher.Names;

                _context.Teacher.Update(exist);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "UpdateTeacher", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo = "Error" };
            }
            return new ResponseService { Message = "Se ha actualizado el profesor", Success = false, Tipo = "Execution" };
        }
    }
}
