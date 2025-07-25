using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEducation.Application.Model;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Interface;
using WebApiEducation.Domain.Model;

namespace WebApiEducation.Application.App
{
    public class StudentApplication
    {
        private readonly IStudentRepository _StudentRepository;
        private IMapper _mapper;

        public StudentApplication(IStudentRepository studentRepository, IMapper mapper)
        {
            _StudentRepository = studentRepository;
            _mapper = mapper;
        }
        
        public async Task<ResponseServiceDTO> AddStudent(StudentDTO student)
        {
            Student request = _mapper.Map<StudentDTO, Student>(student);
            ResponseService response= await _StudentRepository.AddStudent(request);
            return _mapper.Map<ResponseService, ResponseServiceDTO>(response);
        }

        public async Task<ResponseServiceDTO> DeleteStudent(int id)
        {
            ResponseService response =await _StudentRepository.DeleteStudent(id);
            return _mapper.Map<ResponseService, ResponseServiceDTO> (response);
        }

        public async Task<List<StudentDTO>> GetAll()
        {
            List<Student> response = await _StudentRepository.GetAll();
            return _mapper.Map<List<Student>, List<StudentDTO>>(response);
        }

        public async Task<StudentDTO> GetById(int id)
        {
            Student response = await _StudentRepository.GetById(id);
            return _mapper.Map<Student, StudentDTO>(response);
        }
        
        public async Task<ResponseServiceDTO> UpdateStudent(StudentDTO student)
        {
            Student request = _mapper.Map<StudentDTO, Student>(student);
            ResponseService response = await _StudentRepository.UpdateStudent(request);
            return _mapper.Map<ResponseService, ResponseServiceDTO>(response);
        }
    }
}
