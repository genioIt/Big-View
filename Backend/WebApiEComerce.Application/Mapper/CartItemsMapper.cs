using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Model;

namespace WebApiEcommerce.Application.Mapper
{
    public class CartItemsMapper : Profile
    {
       public CartItemsMapper() 
        {
            CartRequest();
            CartRespose();
            CartProductRequest();
            CartProductResponse();
        }

        public void CartRequest()
        {
            CreateMap<CartItems, CartItemsDTO>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
           .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
           .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
        }

        public void CartProductRequest()
        {
            CreateMap<CartProducts, CartProductsDTO>()
           .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
           .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
           .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
           .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
           .ForMember(x => x.isActive, y => y.MapFrom(z => z.isActive));
        }

        public void CartRespose()
        {
            CreateMap<CartItemsDTO, CartItems>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
           .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
           .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
        }
        public void CartProductResponse()
        {
            CreateMap<CartProductsDTO, CartProducts>()
           .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
           .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
           .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
           .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
           .ForMember(x => x.isActive, y => y.MapFrom(z => z.isActive));
        }
    }
}
