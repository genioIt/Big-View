using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Interface;

namespace WebApiEcommerce.Application.App
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IUsersRepository _userRepository;
        private readonly IUserRolesRepository _UserRolesRepository;
        private readonly IJwtProvider _jwtProvider;

        public AuthApplication(IUsersRepository userRepoRepository,
                               IUserRolesRepository userRolesRepository,
                               IJwtProvider jwtProvider)
        {
            _userRepository = userRepoRepository;
            _UserRolesRepository = userRolesRepository;
            _jwtProvider = jwtProvider;

            
        }


        public async Task<AuthResponseDTO> Login(string email, string password)
        {
            var users = await _userRepository.GetByUsernameAndPassword(email, password);
            if (users == null) return null;

            var roles = await _UserRolesRepository.GetRolesByIdUser(users.Id);
            var token = _jwtProvider.GenerateToken(users.Email, roles);

            return new AuthResponseDTO
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60)
            };
        }
    }
}
