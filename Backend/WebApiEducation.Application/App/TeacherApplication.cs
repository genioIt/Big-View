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
    public class TeacherApplication
    {
        private readonly ITeacherRepository _TeacherRepository;
        private IMapper _mapper;

        public TeacherApplication(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _TeacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<ResponseServiceDTO> AddTeacher(TeacherDTO teacher)
        {
            Teacher request = _mapper.Map<TeacherDTO, Teacher>(teacher);
            ResponseService response = await _TeacherRepository.AddTeacher(request);
            return _mapper.Map<ResponseService, ResponseServiceDTO>(response);
        }

        public async Task<ResponseServiceDTO> DeleteTeacher(int id)
        {
            ResponseService response=await _TeacherRepository.DeleteTeacher(id);
            return _mapper.Map<ResponseService, ResponseServiceDTO>(response);
        }


        public async Task<List<TeacherDTO>> GetAll()
        {
            List<Teacher> response = await _TeacherRepository.GetAll();
            return _mapper.Map<List<Teacher>, List<TeacherDTO>>(response);
        }
        public async Task<TeacherDTO> GetById(int id)
        {
            Teacher response = await _TeacherRepository.GetById(id);
            return _mapper.Map<Teacher, TeacherDTO>(response);
        } 
               
        public async Task<ResponseServiceDTO> UpdateTeacher(TeacherDTO student)
        {
            Teacher request = _mapper.Map<TeacherDTO, Teacher>(student);
            ResponseService response = await _TeacherRepository.UpdateTeacher(request);
            return _mapper.Map<ResponseService, ResponseServiceDTO>(response);
        }
    }
}
