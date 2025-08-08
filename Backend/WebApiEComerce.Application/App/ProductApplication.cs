using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;

namespace WebApiEcommerce.Application.App
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductsRepository _productsRepository;
        private IMapper _mapper;

        public ProductApplication(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductsDTO>> GetByCategoryActiveAsync(int idcategory)
        {
            try {
                IEnumerable<Products> products = await _productsRepository.GetByCategoryActiveAsync(idcategory);
                return _mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
            }
            catch(ProductNotFoundException) {
                return null;
            }
        }
    }
}
