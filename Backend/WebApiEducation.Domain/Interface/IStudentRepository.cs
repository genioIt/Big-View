using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Model;

namespace WebApiEducation.Domain.Interface
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<ResponseService> AddStudent(Student student);
        Task<ResponseService> DeleteStudent(int id);
        Task<ResponseService> UpdateStudent(Student student);
    }
}
