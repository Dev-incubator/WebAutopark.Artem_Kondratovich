using AutoMapper;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Entities;

namespace WebAutopark.Mappings
{
    public class DtoEntityProfile : Profile
    {
        public DtoEntityProfile()
        {
            CreateMap<ComponentDto, Component>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
        }
    }
}
