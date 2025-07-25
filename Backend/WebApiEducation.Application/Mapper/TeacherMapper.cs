using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEducation.Domain.Entity;

namespace WebApiEducation.Application.Mapper
{
    public class TeacherMapper : Profile
    {
        public TeacherMapper() {
            TeacherRequest();
            TeacherResponse();
        }
        public void TeacherRequest()
        {
            CreateMap<Teacher, TeacherDTO>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Names, y => y.MapFrom(z => z.Names));
        }
        public void TeacherResponse()
        {
            CreateMap<TeacherDTO, Teacher>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Names, y => y.MapFrom(z => z.Names));
        }
    }
}
