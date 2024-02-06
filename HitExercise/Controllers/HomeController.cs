using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
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

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISupplierRepository supplierRepository)
        {
            _logger = logger;
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = _supplierRepository.GetAll();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Supplier supplier)
        {
            _supplierRepository.Add(supplier);
            TempData["SuccessMessage"] = "ΕΠΙΤΥΧΗΣ ΠΡΟΣΘΗΚΗ ΠΡΟΜΗΘΕΥΤΗ!";

            return RedirectToAction("Index");
        }

        public IActionResult EditForm(int supplierId)
        {
            var supplier = _supplierRepository.GetById(supplierId);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            _supplierRepository.Update(supplier);
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
