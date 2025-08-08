namespace WebApiEcommerce.Domain.Common
{
    public class SessionNotFoundException : EntityNotFoundException
    {
        public SessionNotFoundException(string token) 
            : base("Sesión", "token", token)
        {
        }

        public SessionNotFoundException(int sessionId) 
            : base("Sesión", sessionId)
        {
        }
    }

    public class SessionExpiredException : BusinessRuleException
    {
        public SessionExpiredException(string token)
            : base($"La sesión con token '{token}' ha expirado.", "SESSION_EXPIRED", token)
        {
        }
    }

    public class InvalidTokenException : BusinessRuleException
    {
        public InvalidTokenException()
            : base("El token proporcionado es inválido.", "INVALID_TOKEN")
        {
        }
    }
}