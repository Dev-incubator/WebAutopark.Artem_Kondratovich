using AutoMapper;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Models;

namespace WebAutopark.Mappings
{
    public class ViewModelDtoProfile : Profile
    {
        public ViewModelDtoProfile()
        {
            CreateMap<ComponentViewModel, ComponentDto>().ReverseMap();
            CreateMap<OrderViewModel, OrderDto>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemDto>().ReverseMap();
            CreateMap<VehicleViewModel, VehicleDto>().ReverseMap();
            CreateMap<VehicleTypeViewModel, VehicleTypeDto>().ReverseMap();
        }
    }
}
