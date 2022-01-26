using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services.Interfaces;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IDataService<ComponentDto> _componentDtoService;

        public OrderController(IMapper mapper, IOrderService orderService, IDataService<ComponentDto> componentDtoService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _componentDtoService = componentDtoService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var orderDtos = _orderService.GetAllItems();
            var orderViewModels = _mapper.Map<IEnumerable<OrderViewModel>>(orderDtos);

            return View(orderViewModels);
        }

        [HttpGet]
        public ActionResult Create(int vehicleId, string vehicleModelName)
        {
            OrderViewModel orderViewModel = new OrderViewModel()
            {
                VehicleId = vehicleId,
                Vehicle = new Vehicle() { Model = vehicleModelName },
                Date = DateTime.UtcNow
            };

            return View(orderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var orderDto = _mapper.Map<OrderDto>(orderViewModel);
            var insertedOrderId = _orderService.CreateAndReturnId(orderDto);

            return RedirectToAction("Index", "OrderItem", new { orderId = insertedOrderId });
        }
    }
}
