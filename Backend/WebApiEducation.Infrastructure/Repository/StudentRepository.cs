using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly AudisoftEducationContext _context;
        private readonly ILogWebApiRepository _logWeb;

        public StudentRepository(AudisoftEducationContext context, ILogWebApiRepository logWeb)
        {
            _context = context;
            _logWeb= logWeb;

        }

        public async Task<ResponseService> AddStudent(Student student)
        {
            try
            {
                Student exist = await _context.Student.FindAsync(student.Id);
                if (exist != null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "AddStudent", Message = "Ya existe este estudiante no se puede agregar" });
                    return new ResponseService { Message = "Ya existe este estudiante no se puede agregar", Success = false, Tipo = "Warning" };
                }

                _context.Student.Add(student);
                await _context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "AddStudent", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo = "Error" };
            }
             return new ResponseService { Message = "Ha sido agregado el estudiante", Success = true, Tipo = "Execution" };
        }

        public async Task<ResponseService> DeleteStudent(int id)
        {
            try
            {
                Student exist = await _context.Student.FindAsync(id);
                if (exist == null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "DeleteStudent", Message = "No se ha encontrado el estudiante a borrar" });
                    return new ResponseService { Message = "No se ha encontrado el estudiante a borrar", Success = false, Tipo = "Warning" };
                }

                Note studentNota = await _context.Note.Where(x => x.idStudent == exist.Id).FirstOrDefaultAsync();
                if (studentNota != null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "DeleteStudent", Message = "No se puede eliminar el estudiante por que le fue asignado una nota" });
                    return new ResponseService { Message = "No se puede eliminar el estudiante por que le fue asignado una nota", Success = false, Tipo = "Warning" };
                }

                _context.Student.Remove(exist);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "DeleteStudent", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo = "Error" };
            }
            return new ResponseService { Message = "Ha sido borrado el estudiante", Success = true, Tipo = "Execution" };
        }

        public async Task<List<Student>> GetAll()
        {
            List<Student> students = new List<Student>();
            try
            {
                students=await _context.Student.ToListAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "GetAll", Message = ex.Message });
                return null;
            }
           return students;
        }


        public async Task<Student> GetById(int id)
        {
            Student student = null;
            try
            {
                student = await _context.Student.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "GetById", Message = ex.Message });
                return null;
            }
            return student;
        }
       

        public async Task<ResponseService> UpdateStudent(Student student)
        {
            try
            {
                Student exist = await _context.Student.FindAsync(student.Id);
                if (exist == null)
                {
                    await _logWeb.AddLog(new LogWebApi { Method = "UpdateStudent", Message = "No se ha encontrado el estudiante a Actualizar" });
                    return new ResponseService { Message = "No se ha encontrado el estudiante a Actualizar", Success = false, Tipo = "Warning" };
                }
                exist.Name= student.Name;

                _context.Student.Update(exist);
                await _context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                await _logWeb.AddLog(new LogWebApi { Method = "UpdateStudent", Message = ex.Message });
                return new ResponseService { Message = ex.Message, Success = true, Tipo = "Execution" };
            }
            return new ResponseService { Message = "Se ha actualizado el estudiante", Success = true, Tipo = "Execution" };
        }
    }
}
