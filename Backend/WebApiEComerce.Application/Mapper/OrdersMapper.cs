using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Application.Mapper
{

    public class OrdersMapper :Profile
    {
        public OrdersMapper() {
            OrdersRequest();
            OrdersResponse();
        }

        public void OrdersRequest()
        {
            CreateMap<Orders, OrdersDTO>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
           .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
           .ForMember(x => x.ShippingAddress, y => y.MapFrom(z => z.ShippingAddress))
           .ForMember(x => x.ShippingCity, y => y.MapFrom(z => z.ShippingCity))
           .ForMember(x => x.ShippingZipCode, y => y.MapFrom(z => z.ShippingZipCode))
           .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod))
           .ForMember(x => x.PaymentStatus, y => y.MapFrom(z => z.PaymentStatus))
           .ForMember(x => x.CompletedAt, y => y.MapFrom(z => z.CompletedAt));

        }

        public void OrdersResponse()
        {
            CreateMap<OrdersDTO, Orders>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
           .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
           .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
           .ForMember(x => x.ShippingAddress, y => y.MapFrom(z => z.ShippingAddress))
           .ForMember(x => x.ShippingCity, y => y.MapFrom(z => z.ShippingCity))
           .ForMember(x => x.ShippingZipCode, y => y.MapFrom(z => z.ShippingZipCode))
           .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod))
           .ForMember(x => x.PaymentStatus, y => y.MapFrom(z => z.PaymentStatus))
           .ForMember(x => x.CompletedAt, y => y.MapFrom(z => z.CompletedAt));

        }
    }
}
