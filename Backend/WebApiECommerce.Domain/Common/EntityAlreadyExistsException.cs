namespace WebApiEcommerce.Domain.Common
{
    public class EntityAlreadyExistsException : DomainException
    {
        public EntityAlreadyExistsException(string entityName, string field, object value)
            : base($"La entidad '{entityName}' con {field} '{value}' ya existe.", "ENTITY_ALREADY_EXISTS", entityName, field, value)
        {
        }

        public EntityAlreadyExistsException(string entityName, object id)
            : base($"La entidad '{entityName}' con ID '{id}' ya existe.", "ENTITY_ALREADY_EXISTS", entityName, id)
        {
        }
    }
}