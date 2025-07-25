using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEducation.Domain.Entity;

namespace WebApiEducation.Application.Mapper
{
    public class StudentMapper : Profile
    {
        public StudentMapper() {
            StudentRequest();
            StudentResponse();
        }

        public void StudentRequest()
        {
            CreateMap<Student, StudentDTO>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
        public void StudentResponse()
        {
            CreateMap<StudentDTO, Student>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
