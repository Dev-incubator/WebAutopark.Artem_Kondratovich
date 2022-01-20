using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDtoService<ComponentDto> _componentDtoService;

        public ComponentController(IMapper mapper, IDtoService<ComponentDto> componentDtoService)
        {
            _mapper = mapper;
            _componentDtoService = componentDtoService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var componentDtoItems = _componentDtoService.GetAllItems();
            var componentViewModels = _mapper.Map<IEnumerable<ComponentViewModel>>(componentDtoItems);

            return View(componentViewModels);
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComponentViewModel componentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var componentDto = _mapper.Map<ComponentDto>(componentViewModel);
            _componentDtoService.Create(componentDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var componentDto = _componentDtoService.GetItem(id);

            if (componentDto is null)
                return NotFound();

            var componentViewModel = _mapper.Map<ComponentViewModel>(componentDto);

            return View(componentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComponentViewModel componentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var componentDto = _mapper.Map<ComponentDto>(componentViewModel);
            _componentDtoService.Update(componentDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int componentId)
        {
            _componentDtoService.Delete(componentId);
            return RedirectToAction(nameof(Index));
        }
    }
}
