using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Application.Mapper;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;

namespace WebApiEcommerce.Application.App
{
    public class UserApplication : IUserApplication
    {
        private readonly IUsersRepository _usersRepository;
        private IMapper _mapper;

        public UserApplication(IUsersRepository usersRepository, IMapper mapper)
        { 
           _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<ResponseServiceDTO> CreateUserAsync(UsersDTO userDto)
        {
            try
            {
                // Validar datos de entrada
                if (string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Name))
                {
                    return new ResponseServiceDTO
                    {
                        Success = false,
                        Message = "El email y el nombre son requeridos.",
                        Tipo = "ValidationError"
                    };
                }

                // Convertir DTO a entidad usando mapper
                Users users= _mapper.Map<UsersDTO, Users>(userDto);
                
                // Crear usuario
                Users createdUser = await _usersRepository.AddAsync(users);

                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = "Usuario creado exitosamente.",
                    Tipo = "Success"
                };
            }
            catch (UserAlreadyExistsException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "BusinessError"
                };
            }
            catch (DomainException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "DomainError"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }

        public async Task<ResponseServiceDTO> DeleteUserAsync(int userId)
        {
            try
            {
                if (userId <= 0)
                {
                    return new ResponseServiceDTO
                    {
                        Success = false,
                        Message = "ID de usuario inválido.",
                        Tipo = "ValidationError"
                    };
                }
                bool deleted = await _usersRepository.DeleteAsync(userId);

                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = "Usuario eliminado exitosamente.",
                    Tipo = "Success"
                };
            }
            catch (UserNotFoundException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "NotFound"
                };
            }
            catch (DomainException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "DomainError"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            try
            {
                return await _usersRepository.EmailExistsAsync(email);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UsersDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _usersRepository.GetAllAsync();

                // Convertir DTO a entidad usando mapper
                return _mapper.Map<IEnumerable<Users>, IEnumerable<UsersDTO>>(users);
            }
            catch (Exception)
            {
                return new List<UsersDTO>();
            }
        }

        public async Task<UsersDTO> GetUserByEmailAsync(string email)
        {
            try
            {
                Users users = await _usersRepository.GetByEmailAsync(email);
                // Convertir DTO a entidad usando mapper
                return _mapper.Map<Users, UsersDTO>(users);
            }
            catch (UserNotFoundException)
            {
                return null;
            }
        }
        

        public async Task<UsersDTO> GetUserByIdAsync(int userId)
        {
            try
            {
                Users user = await _usersRepository.GetByIdAsync(userId);
                // Convertir DTO a entidad usando mapper
                return _mapper.Map<Users, UsersDTO>(user);
            }
            catch (UserNotFoundException)
            {
                return null;
            }
        }

        public async Task<ResponseServiceDTO> UpdateUserAsync(UsersDTO userDto)
        {
            try
            {
                // Validar datos de entrada
                if (userDto.Id <= 0)
                {
                    return new ResponseServiceDTO
                    {
                        Success = false,
                        Message = "ID de usuario inválido.",
                        Tipo = "ValidationError"
                    };
                }

                // Obtener usuario existente
                Users existingUser = await _usersRepository.GetByIdAsync(userDto.Id);

                // Actualizar propiedades usando mapper
                Users userDTO = _mapper.Map<Users, Users>(existingUser);

                // Actualizar usuario
                await _usersRepository.UpdateAsync(userDTO);

                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = "Usuario actualizado exitosamente.",
                    Tipo = "Success"
                };
            }
            catch (UserNotFoundException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "NotFound"
                };
            }
            catch (DomainException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "DomainError"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }

        public async Task<ResponseServiceDTO> ValidateUserCredentialsAsync(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    return new ResponseServiceDTO
                    {
                        Success = false,
                        Message = "Email y contraseña son requeridos.",
                        Tipo = "ValidationError"
                    };
                }

                var user = await _usersRepository.GetByEmailAsync(email);

                // Aquí deberías implementar la lógica de verificación de contraseña
                // Por ejemplo, usando BCrypt o similar
                if (user.PasswordHash == password) // Esto es solo para ejemplo, usa hash real
                {
                    return new ResponseServiceDTO
                    {
                        Success = true,
                        Message = "Credenciales válidas.",
                        Tipo = "Success"
                    };
                }
                else
                {
                    return new ResponseServiceDTO
                    {
                        Success = false,
                        Message = "Credenciales inválidas.",
                        Tipo = "InvalidCredentials"
                    };
                }
            }
            catch (UserNotFoundException)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Usuario no encontrado.",
                    Tipo = "NotFound"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }
    }
}
