using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
using HitExercise.Interfaces.Services;
using HitExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HitExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IValidationService _validationService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISupplierRepository supplierRepository, IValidationService validationService)
        {
            _logger = logger;
            _supplierRepository = supplierRepository;
            _validationService = validationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = _supplierRepository.GetAll();
            return View(suppliers);
        }

        [HttpGet]
        public IActionResult SuppliersByCategory(int CategoryId)
        {
            var suppliers = _supplierRepository.GetSuppliersByCategoryId(CategoryId);
            return View("Index",suppliers);
        }


        [HttpGet]
        public IActionResult SuppliersByCountry(int CountryId)
        {
            var suppliers = _supplierRepository.GetSuppliersByCountryId(CountryId);
            return View("Index", suppliers);
        }

        [HttpGet]
        public IActionResult SuppliersBySearching(string searchingString)
        {
            var suppliers = _supplierRepository.GetSuppliersBySearching(searchingString);
            return View("Index", suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (!_validationService.IsNameUnique(supplier.Name))
                {
                    ModelState.AddModelError("name", "Η ονομασία υπάρχει ήδη.");
                    return View(supplier);
                }
                if (!_validationService.IsAfmOk(supplier.Afm))
                {
                    ModelState.AddModelError("afm", "To AΦΜ δεν είναι έγκυρο.");
                    return View(supplier);
                }

                _supplierRepository.Add(supplier);
                TempData["SuccessMessage"] = "ΕΠΙΤΥΧΗΣ ΠΡΟΣΘΗΚΗ ΠΡΟΜΗΘΕΥΤΗ!";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int supplierId)
        {
            var supplier = _supplierRepository.GetById(supplierId);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (!_validationService.IsEditableNameUnique(supplier.Name))
                {
                    ModelState.AddModelError("name", "Η ονομασία υπάρχει ήδη.");
                    return View(supplier);
                }
                if (!_validationService.IsAfmOk(supplier.Afm))
                {
                    ModelState.AddModelError("afm", "To AΦΜ δεν είναι έγκυρο.");
                    return View(supplier);
                }

                _supplierRepository.Update(supplier);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int SupplierId)
        {
            Supplier supplier = _supplierRepository.GetById(SupplierId);
            _supplierRepository.Delete(supplier);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _supplierRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
