using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<OrderDetail, CreateOrderRequestDto>();
            CreateMap<ProductDetail, CreateOrderRequestDto>();
            CreateMap<Order, CreateOrderRequestDto>().ForMember(d => d.CustomerName, o => o.MapFrom(s => s.CustomerName)).
                ForMember(d => d.CustomerEmail, o => o.MapFrom(s => s.CustomerEmail)).
                ForMember(d => d.CustomerGSM, o => o.MapFrom(s => s.CustomerGSM));
        }
    }
}
