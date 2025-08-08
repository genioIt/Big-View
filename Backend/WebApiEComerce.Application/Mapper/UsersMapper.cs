using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Application.Mapper
{
    public class UsersMapper : Profile
    {
        public UsersMapper() {
            UsersRequest();
            UsersResponse();
        }


        public void UsersRequest()
        {
            CreateMap<Users, UsersDTO>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
           .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.PasswordHash));
        }

        public void UsersResponse()
        {
            CreateMap<UsersDTO, Users>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
           .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.PasswordHash));
        }
    }
}
