using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDataService<OrderItemDto> _orderItemDtoService;

        public OrderItemController(IMapper mapper, IDataService<OrderItemDto> orderItemDtoService)
        {
            _mapper = mapper;
            _orderItemDtoService = orderItemDtoService;
        }
    }
}
