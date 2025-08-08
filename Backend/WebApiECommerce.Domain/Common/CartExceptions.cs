namespace WebApiEcommerce.Domain.Common
{
    public class CartItemNotFoundException : DomainException
    {
        public CartItemNotFoundException(int userId, int productId)
            : base($"Elemento del carrito no encontrado para el usuario '{userId}' y producto '{productId}'.", "CART_ITEM_NOT_FOUND", userId, productId)
        {
        }
    }

    public class EmptyCartException : BusinessRuleException
    {
        public EmptyCartException(int userId)
            : base($"El carrito del usuario '{userId}' está vacío.", "EMPTY_CART", userId)
        {
        }
    }

    public class InvalidQuantityException : BusinessRuleException
    {
        public InvalidQuantityException(int quantity)
            : base($"La cantidad debe ser mayor a cero. Cantidad proporcionada: {quantity}", "INVALID_QUANTITY", quantity)
        {
        }
    }
}