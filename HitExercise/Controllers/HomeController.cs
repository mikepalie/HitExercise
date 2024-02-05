﻿using HitExercise.Data;
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
        private readonly AppDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.Include(s => s.Category).Include(s => s.Country).ToList();
            return View(suppliers);
        }

        [HttpPost]
        public IActionResult Create( string name, int category, int afm, string address, int phone, string email, int country, bool isActive)
        {
            Supplier newSupplier = new Supplier() { Name = name, CategoryId = category, Afm = afm, Address = address, Phone = phone, Email = email, CountryId = country, IsActive = isActive };
            _context.Suppliers.Add(newSupplier);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "ΕΠΙΤΥΧΗΣ ΠΡΟΣΘΗΚΗ ΠΡΟΜΗΘΕΥΤΗ!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int SupplierId, string name, int category, int afm, string address, int phone, string email, int country, string isActive)
        {
            var existingSupplier = _context.Suppliers.Find(SupplierId);
            if (existingSupplier != null)
            {
                existingSupplier.Name = name;
                existingSupplier.CategoryId = category;
                existingSupplier.Afm = afm;
                existingSupplier.Address = address;
                existingSupplier.Phone = phone;
                existingSupplier.Email = email;
                existingSupplier.CountryId = country;
                existingSupplier.IsActive = (isActive == "true");
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int SupplierId)
        {
            var existingSupplier = _context.Suppliers.Find(SupplierId);
            if (existingSupplier != null)
            {
                _context.Suppliers.Remove(existingSupplier);
            }
            _context.SaveChanges();

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
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
