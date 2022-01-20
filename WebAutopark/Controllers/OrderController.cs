using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDtoService<OrderDto> _orderDtoService;

        public OrderController(IMapper mapper, IDtoService<OrderDto> orderDtoService)
        {
            _mapper = mapper;
            _orderDtoService = orderDtoService;
        }
    }
}
