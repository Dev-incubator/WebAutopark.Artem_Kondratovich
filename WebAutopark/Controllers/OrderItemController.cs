using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services.Interfaces;
using WebAutopark.Core.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemService _orderItemService;
        private readonly IDataService<ComponentDto> _componentDtoService;

        public OrderItemController(IMapper mapper, IOrderItemService orderItemService, IDataService<ComponentDto> componentDtoService)
        {
            _mapper = mapper;
            _orderItemService = orderItemService;
            _componentDtoService = componentDtoService;
        }

        [NonAction]
        private List<SelectListItem> GetComponentsForSelect()
        {
            var componentDtoItems = _componentDtoService.GetAllItems();
            var selectItems = new List<SelectListItem>();

            foreach (var component in componentDtoItems)
            {
                selectItems.Add(new SelectListItem { Text = component.Name, Value = component.ComponentId.ToString() });
            }

            return selectItems;
        }

        [HttpGet]
        public ActionResult Index(int orderId)
        {
            var orderItemDtoItems = _orderItemService.GetItemsByOrderId(orderId);
            var orderItemViewModels = _mapper.Map<IEnumerable<OrderItemViewModel>>(orderItemDtoItems);

            ViewBag.OrderId = orderId;

            return View(orderItemViewModels);
        }

        [HttpGet]
        public ActionResult Create(int orderId)
        {
            OrderItemViewModel viewModel = new OrderItemViewModel() { OrderId = orderId };
            ViewBag.Components = GetComponentsForSelect();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderItemViewModel orderItemViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Components = GetComponentsForSelect();
                return View();
            }

            var orderItemDto = _mapper.Map<OrderItemDto>(orderItemViewModel);
            _orderItemService.Create(orderItemDto);

            return RedirectToAction(nameof(Index), new { orderId = orderItemViewModel.OrderId });
        }
    }
}
