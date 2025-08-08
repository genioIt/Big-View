using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Application.Mapper
{
    public class UserRolesMapper : Profile
    {
        public UserRolesMapper()
        {
            UserRolesRequest();
            UserRolesResponse();    
        }

        public void UserRolesRequest()
        {
            CreateMap<UserRoles, UserRolesDTO>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.IdUsers, y => y.MapFrom(z => z.IdUsers))
               .ForMember(x => x.IdRoles, y => y.MapFrom(z => z.IdRoles));
        }

        public void UserRolesResponse()
        {
            CreateMap<UserRolesDTO, UserRoles>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
              .ForMember(x => x.IdUsers, y => y.MapFrom(z => z.IdUsers))
              .ForMember(x => x.IdRoles, y => y.MapFrom(z => z.IdRoles));
        }
    }
}
