using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEducation.Domain.Entity;

namespace WebApiEducation.Application.Mapper
{
    public class NoteMapper : Profile
    {
        public NoteMapper() {
            NoteRequest();
            NoteResponse();
        }

     public void NoteRequest()
        {
            CreateMap<Note, NoteDTO>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.idTeacher, y => y.MapFrom(z => z.idTeacher))
               .ForMember(x => x.idStudent, y => y.MapFrom(z => z.idStudent))
               .ForMember(x => x.value, y => y.MapFrom(z => z.Value));
        }

        public void NoteResponse()
        {
            CreateMap<NoteDTO, Note>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.idTeacher, y => y.MapFrom(z => z.idTeacher))
               .ForMember(x => x.idStudent, y => y.MapFrom(z => z.idStudent))
               .ForMember(x => x.Value, y => y.MapFrom(z => z.value));
        }
    }
}
