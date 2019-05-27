using AutoMapper;
using CorePlayground.Data.Entities;
using CorePlayground.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlayground.Data
{
    public class DutchMapperProfile : Profile
    {
        public DutchMapperProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, src => src.MapFrom(s => s.Id))
                .ReverseMap();
        }
    }
}
