namespace WebApiEcommerce.Domain.Common
{
    public class CategoryNotFoundException : EntityNotFoundException
    {
        public CategoryNotFoundException(int categoryId) 
            : base("Categoría", categoryId)
        {
        }

        public CategoryNotFoundException(string categoryName) 
            : base("Categoría", "nombre", categoryName)
        {
        }
    }

    public class CategoryAlreadyExistsException : EntityAlreadyExistsException
    {
        public CategoryAlreadyExistsException(string categoryName) 
            : base("Categoría", "nombre", categoryName)
        {
        }
    }

    public class CategoryHasProductsException : BusinessRuleException
    {
        public CategoryHasProductsException(string categoryName)
            : base($"No se puede eliminar la categoría '{categoryName}' porque tiene productos asociados.", 
                   "CATEGORY_HAS_PRODUCTS", categoryName)
        {
        }
    }
}