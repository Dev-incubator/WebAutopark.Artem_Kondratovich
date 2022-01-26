using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services.Interfaces;
using WebAutopark.Core.Enums;
using WebAutopark.Core.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicleService;
        private readonly IDataService<VehicleTypeDto> _vehicleTypeDtoService;

        public VehicleController(IMapper mapper, IVehicleService vehicleService,
            IDataService<VehicleTypeDto> vehicleTypeDtoService)
        {
            _mapper = mapper;
            _vehicleService = vehicleService;
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
        public ActionResult Index(SortState sortOrder = SortState.IdAsc)
        {
            ViewBag.ModelSort = sortOrder == SortState.ModelAsc ? SortState.ModelDesc : SortState.ModelAsc;
            ViewBag.VehicleTypeSort = sortOrder == SortState.VehicleTypeAsc ? SortState.VehicleTypeDesc : SortState.VehicleTypeAsc;
            ViewBag.MileageSort = sortOrder == SortState.MileageAsc ? SortState.MileageDesc : SortState.MileageAsc;

            var vehicleDtoItems = _vehicleService.GetAllSortedItems(sortOrder);
            var vehicleViewModels = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicleDtoItems);

            return View(vehicleViewModels);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var vehicleDto = _vehicleService.GetItem(id);

            if (vehicleDto is null)
                return NotFound();

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleDto);

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
            _vehicleService.Create(vehicleDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vehicleDto = _vehicleService.GetItem(id);

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
                return View(vehicleViewModel);
            }

            var vehicleDto = _mapper.Map<VehicleDto>(vehicleViewModel);
            _vehicleService.Update(vehicleDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int vehicleId)
        {
            _vehicleService.Delete(vehicleId);
            return RedirectToAction(nameof(Index));
        }
    }
}
