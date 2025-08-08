using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Application.Mapper
{
    public class ProductCategoriesMapper : Profile
    {
        public ProductCategoriesMapper() {
            ProductCategoriesRequest();
            ProductCategoriesResponse();
        }

        public void ProductCategoriesRequest()
        {
            CreateMap<ProductCategories, ProductCategoriesDTO>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
        public void ProductCategoriesResponse()
        {
            CreateMap<ProductCategoriesDTO, ProductCategories>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}
