using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Application.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            ProductRequest();
            ProductResponse();
        }

        public void ProductRequest()
        {
           CreateMap<Products, ProductsDTO>()
          .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
          .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
          .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
          .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
          .ForMember(x => x.IdCategory, y => y.MapFrom(z => z.IdCategory))
          .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
          .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating))
          .ForMember(x => x.Stock, y => y.MapFrom(z => z.Stock));
        }
        public void ProductResponse()
        {
            CreateMap<ProductsDTO, Products>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
           .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
           .ForMember(x => x.IdCategory, y => y.MapFrom(z => z.IdCategory))
           .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
           .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating))
           .ForMember(x => x.Stock, y => y.MapFrom(z => z.Stock));
        }
    }
}
