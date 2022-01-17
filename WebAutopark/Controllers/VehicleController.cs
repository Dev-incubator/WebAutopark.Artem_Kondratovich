using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Core.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDtoService<VehicleDto> _vehicleDtoService;
        private readonly IDtoService<VehicleTypeDto> _vehicleTypeDtoService;

        public VehicleController(IMapper mapper, IDtoService<VehicleDto> vehicleDtoService,
            IDtoService<VehicleTypeDto> vehicleTypeDtoService)
        {
            _mapper = mapper;
            _vehicleDtoService = vehicleDtoService;
            _vehicleTypeDtoService = vehicleTypeDtoService;
        }

        [NonAction]
        private List<SelectListItem> GetVehicleTypesForSelect()
        {
            var vehicleTypeDtoItems = _vehicleTypeDtoService.GetAllItems();
            var selectItems = new List<SelectListItem>();

            foreach (var vehicleType in vehicleTypeDtoItems)
            {
                selectItems.Add(new SelectListItem { Text = vehicleType.TypeName, Value = vehicleType.VehicleTypeId.ToString() });
            }

            return selectItems;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var vehicleDtoItems = _vehicleDtoService.GetAllItems();
            var vehicleViewModels = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicleDtoItems);

            return View(vehicleViewModels);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var vehicleDto = _vehicleDtoService.GetItem(id);

            if (vehicleDto is null)
                return NotFound();

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleDto);
            ViewBag.VehicleType = _vehicleTypeDtoService.GetItem(vehicleDto.VehicleTypeId);

            return View(vehicleViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.VehicleTypes = GetVehicleTypesForSelect();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.VehicleTypes = GetVehicleTypesForSelect();
                return View();
            }

            var vehicleDto = _mapper.Map<VehicleDto>(vehicleViewModel);
            _vehicleDtoService.Create(vehicleDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vehicleDto = _vehicleDtoService.GetItem(id);

            if (vehicleDto is null)
                return NotFound();

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleDto);
            ViewBag.VehicleTypes = GetVehicleTypesForSelect();

            return View(vehicleViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.VehicleTypes = GetVehicleTypesForSelect();
                return View();
            }

            var vehicleDto = _mapper.Map<VehicleDto>(vehicleViewModel);
            _vehicleDtoService.Update(vehicleDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int vehicleId)
        {
            _vehicleDtoService.Delete(vehicleId);
            return RedirectToAction(nameof(Index));
        }
    }
}
