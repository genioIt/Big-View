using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Model;

namespace WebApiEducation.Domain.Interface
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAll();
        Task<Teacher> GetById(int id);
        Task<ResponseService> AddTeacher(Teacher teacher);
        Task<ResponseService> DeleteTeacher(int id);
        Task<ResponseService> UpdateTeacher(Teacher teacher);
    }
}
