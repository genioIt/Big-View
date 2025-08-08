namespace WebApiEcommerce.Domain.Common
{
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string entityName, object id)
            : base($"La entidad '{entityName}' con ID '{id}' no fue encontrada.", "ENTITY_NOT_FOUND", entityName, id)
        {
        }

        public EntityNotFoundException(string entityName, string field, object value)
            : base($"La entidad '{entityName}' con {field} '{value}' no fue encontrada.", "ENTITY_NOT_FOUND", entityName, field, value)
        {
        }
    }
}