namespace WebApiEcommerce.Domain.Common
{
    public class UserNotFoundException : EntityNotFoundException
    {
        public UserNotFoundException(int userId) 
            : base("Usuario", userId)
        {
        }

        public UserNotFoundException(string email) 
            : base("Usuario", "email", email)
        {
        }
    }

    public class UserAlreadyExistsException : EntityAlreadyExistsException
    {
        public UserAlreadyExistsException(string email) 
            : base("Usuario", "email", email)
        {
        }
    }

    public class InvalidCredentialsException : BusinessRuleException
    {
        public InvalidCredentialsException() 
            : base("Las credenciales proporcionadas son inválidas.", "INVALID_CREDENTIALS")
        {
        }
    }
}