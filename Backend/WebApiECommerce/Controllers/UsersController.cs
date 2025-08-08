using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Application.App;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Interface;

namespace WebApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        private readonly IUserRolesApplication _userRolesApplication;
        private readonly UserRolesDTO _UserRoles;

        public UsersController(IUserApplication UserApplication, 
                               IUserRolesApplication UserRolesApplication, 
                               UserRolesDTO UserRoles)
        {
            _userApplication = UserApplication;
            _userRolesApplication = UserRolesApplication;
            _UserRoles = UserRoles;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UsersDTO userDto)
        {
            var result = await _userApplication.CreateUserAsync(userDto);
            _UserRoles.IdUsers = userDto.Id;
            _UserRoles.IdRoles = 4; 

            if (result.Success)
            {
                var userRol = await _userRolesApplication.CreateUserRolesAsync(_UserRoles);
                if (result.Success)
                {
                    return Ok(result);
                }
                   
            }
            return result.Tipo switch
            {
                "ValidationError" => BadRequest(result),
                "BusinessError" => Conflict(result),
                "NotFound" => NotFound(result),
                _ => StatusCode(500, result)
            };
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userApplication.GetUserByIdAsync(id);

            if (user == null)
                return NotFound(new { message = "Usuario no encontrado" });

            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userApplication.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsersDTO userDto)
        {
            userDto.Id = id;
            var result = await _userApplication.UpdateUserAsync(userDto);

            if (result.Success)
                return Ok(result);

            return result.Tipo switch
            {
                "ValidationError" => BadRequest(result),
                "NotFound" => NotFound(result),
                _ => StatusCode(500, result)
            };
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userApplication.DeleteUserAsync(id);

            if (result.Success)
                return Ok(result);

            return result.Tipo switch
            {
                "NotFound" => NotFound(result),
                _ => StatusCode(500, result)
            };
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateCredentials([FromBody] LoginRequest request)
        {
            var result = await _userApplication.ValidateUserCredentialsAsync(request.Email, request.Password);

            if (result.Success)
                return Ok(result);

            return result.Tipo switch
            {
                "ValidationError" => BadRequest(result),
                "NotFound" => NotFound(result),
                "InvalidCredentials" => Unauthorized(result),
                _ => StatusCode(500, result)
            };
        }

        [HttpGet("CheckEmailExists/{email}")]
        public async Task<IActionResult> CheckEmailExists(string email)
        {
            var exists = await _userApplication.EmailExistsAsync(email);
            return Ok(new { exists });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
