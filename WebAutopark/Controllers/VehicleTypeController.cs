using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDtoService<VehicleTypeDto> _vehicleTypeDtoService;

        public VehicleTypeController(IMapper mapper, IDtoService<VehicleTypeDto> vehicleTypeDtoService)
        {
            _mapper = mapper;
            _vehicleTypeDtoService = vehicleTypeDtoService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var vehicleTypeDtoItems = _vehicleTypeDtoService.GetAllItems();
            var vehicleTypeViewModels = _mapper.Map<IEnumerable<VehicleTypeViewModel>>(vehicleTypeDtoItems);

            return View(vehicleTypeViewModels);
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var vehicleTypeDto = _mapper.Map<VehicleTypeDto>(vehicleTypeViewModel);
            _vehicleTypeDtoService.Create(vehicleTypeDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vehicleTypeDto = _vehicleTypeDtoService.GetItem(id);

            if (vehicleTypeDto is null)
                return NotFound();

            var vehicleTypeViewModel = _mapper.Map<VehicleTypeViewModel>(vehicleTypeDto);

            return View(vehicleTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicleTypeViewModel);
            }

            var vehicleTypeDto = _mapper.Map<VehicleTypeDto>(vehicleTypeViewModel);
            _vehicleTypeDtoService.Update(vehicleTypeDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int vehicleTypeId)
        {
            _vehicleTypeDtoService.Delete(vehicleTypeId);
            return RedirectToAction(nameof(Index));
        }
    }
}
