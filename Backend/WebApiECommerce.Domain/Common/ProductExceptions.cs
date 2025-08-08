namespace WebApiEcommerce.Domain.Common
{
    public class ProductNotFoundException : EntityNotFoundException
    {
        public ProductNotFoundException(int productId) 
            : base("Producto", productId)
        {
        }

        public ProductNotFoundException(string productName) 
            : base("Producto", "nombre", productName)
        {
        }
    }

    public class InsufficientStockException : BusinessRuleException
    {
        public InsufficientStockException(string productName, int requestedQuantity, int availableStock)
            : base($"Stock insuficiente para el producto '{productName}'. Solicitado: {requestedQuantity}, Disponible: {availableStock}", 
                   "INSUFFICIENT_STOCK", productName, requestedQuantity, availableStock)
        {
        }
    }

    public class ProductNotActiveException : BusinessRuleException
    {
        public ProductNotActiveException(string productName)
            : base($"El producto '{productName}' no está activo.", "PRODUCT_NOT_ACTIVE", productName)
        {
        }
    }
}