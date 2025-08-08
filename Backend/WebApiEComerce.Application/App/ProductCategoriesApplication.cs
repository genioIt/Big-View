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
    public class ProductCategoriesApplication : IProductCategoriesApplication
    {
        private readonly IProductCategoriesRepository _IProductCategoriesRepository;
        private IMapper _mapper;

        public ProductCategoriesApplication(IProductCategoriesRepository productCategoriesRepository, IMapper mapper)
        {
            _IProductCategoriesRepository = productCategoriesRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductCategoriesDTO>> GetActiveAsync()
        {
            try
            {
            
                IEnumerable<ProductCategories> Categories = await _IProductCategoriesRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<ProductCategories>, IEnumerable<ProductCategoriesDTO>>(Categories);
            }
            catch (CategoryNotFoundException)
            {
                return null;
            }
        }
    }
}
