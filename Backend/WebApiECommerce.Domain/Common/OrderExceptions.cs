using WebApiEcommerce.Domain.Enum;

namespace WebApiEcommerce.Domain.Common
{
    public class OrderNotFoundException : EntityNotFoundException
    {
        public OrderNotFoundException(int orderId) 
            : base("Orden", orderId)
        {
        }
    }

    public class OrderAlreadyCompletedException : BusinessRuleException
    {
        public OrderAlreadyCompletedException(int orderId)
            : base($"La orden con ID '{orderId}' ya ha sido completada.", "ORDER_ALREADY_COMPLETED", orderId)
        {
        }
    }

    public class OrderCannotBeCancelledException : BusinessRuleException
    {
        public OrderCannotBeCancelledException(int orderId, Status currentStatus)
            : base($"La orden con ID '{orderId}' no puede ser cancelada. Estado actual: {currentStatus}", 
                   "ORDER_CANNOT_BE_CANCELLED", orderId, currentStatus)
        {
        }
    }

    public class EmptyOrderException : BusinessRuleException
    {
        public EmptyOrderException()
            : base("No se puede crear una orden sin elementos.", "EMPTY_ORDER")
        {
        }
    }

    public class InvalidOrderAmountException : BusinessRuleException
    {
        public InvalidOrderAmountException(decimal amount)
            : base($"El monto de la orden debe ser mayor a cero. Monto actual: {amount}", "INVALID_ORDER_AMOUNT", amount)
        {
        }
    }
}