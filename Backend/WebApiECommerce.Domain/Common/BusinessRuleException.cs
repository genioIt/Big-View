namespace WebApiEcommerce.Domain.Common
{
    public class BusinessRuleException : DomainException
    {
        public BusinessRuleException(string message, string errorCode = "BUSINESS_RULE_VIOLATION")
            : base(message, errorCode)
        {
        }

        public BusinessRuleException(string message, string errorCode, params object[] parameters)
            : base(message, errorCode, parameters)
        {
        }
    }
}