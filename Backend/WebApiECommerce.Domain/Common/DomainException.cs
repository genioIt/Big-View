using System;

namespace WebApiEcommerce.Domain.Common
{
    public abstract class DomainException : Exception
    {
        public string ErrorCode { get; }
        public object[] Parameters { get; }

        protected DomainException(string message, string errorCode = null, params object[] parameters) 
            : base(message)
        {
            ErrorCode = errorCode;
            Parameters = parameters;
        }

        protected DomainException(string message, Exception innerException, string errorCode = null, params object[] parameters) 
            : base(message, innerException)
        {
            ErrorCode = errorCode;
            Parameters = parameters;
        }
    }
}