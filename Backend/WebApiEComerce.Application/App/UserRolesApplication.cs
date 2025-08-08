using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;

namespace WebApiEcommerce.Application.App
{
    public class UserRolesApplication
    {
        private readonly IUserRolesRepository _UserRolesRepository;
        private IMapper _mapper;

        public UserRolesApplication(IUserRolesRepository userRolesRepository, IMapper mapper)
        {
            _UserRolesRepository = userRolesRepository;
            _mapper = mapper;
        }

        public async Task<ResponseServiceDTO> CreateUserRolesAsync(UserRolesDTO entity)
        {
             try
            {
                var userRoles = _mapper.Map<UserRolesDTO,UserRoles>(entity);
                await _UserRolesRepository.AddAsync(userRoles);
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = "User role added successfully.",
                    Tipo = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "Error"
                };
            }
        }
    }
}
