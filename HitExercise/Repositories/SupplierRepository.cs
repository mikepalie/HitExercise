using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
using HitExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HitExercise.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Supplier> GetAll()
        {
            var suppliers = _context.Suppliers.Include(s => s.Category).Include(s => s.Country).ToList();
            return suppliers;
        }

        public void Add(Supplier newSupplier)
        {
            _context.Suppliers.Add(newSupplier);
            _context.SaveChanges();
        }
        public void Update(Supplier newSupplier)
        {
            var existingSupplier = _context.Suppliers.Find(newSupplier.SupplierId);
            if (existingSupplier != null)
            {
                existingSupplier.Name = newSupplier.Name;
                existingSupplier.CategoryId = newSupplier.CategoryId;
                existingSupplier.Afm = newSupplier.Afm;
                existingSupplier.Address = newSupplier.Address;
                existingSupplier.Phone = newSupplier.Phone;
                existingSupplier.Email = newSupplier.Email;
                existingSupplier.CountryId = newSupplier.CountryId;
                existingSupplier.IsActive = newSupplier.IsActive;
            }
            _context.SaveChanges();
        }

        public void Delete(Supplier supplier)
        {
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
            }
            _context.SaveChanges();
        }

        public Supplier GetById(int id)
        {
            Supplier supplier = _context.Suppliers.Find(id);
            return supplier;
        }

        public IEnumerable<Supplier> GetSuppliersByCategoryId(int id)
        {
            var suppliers = _context.Suppliers.Where(s=>s.CategoryId == id).Include(s => s.Category).Include(s => s.Country).ToList();
            return suppliers;
        }

        public IEnumerable<Supplier> GetSuppliersByCountryId(int id)
        {
            var suppliers = _context.Suppliers.Where(s => s.CountryId == id).Include(s => s.Category).Include(s => s.Country).ToList();
            return suppliers;
        }

        public IEnumerable<Supplier> GetSuppliersBySearching(string searchingString)
        {
            var suppliers = _context.Suppliers.Where(s => s.Name.Contains(searchingString)).Include(s=>s.Category).Include(s=>s.Country).ToList();
            return suppliers;
        }

        public bool ExistsWithName(string name)
        {
            return _context.Suppliers.Any(s => s.Name == name);

        }
        public bool ExistsEditableName(string name)
        {
            var results = _context.Suppliers.Where(s => s.Name == name).ToList();
            return results.Count > 1 ? true : false;
        }

        public bool isAfmValid(string afmNumber)
        {
            // Checks if the afmNumber has the correct length
            if (afmNumber.Length != 9)
                return false;

            // Extracts the last digit
            int lastDigit;
            if (!int.TryParse(afmNumber.Substring(8, 1), out lastDigit))
                return false;

            // Calculates the checksum
            int checksum = 0;
            for (int i = 0; i < 8; i++)
            {
                int digit;
                if (!int.TryParse(afmNumber.Substring(i, 1), out digit))
                    return false;

                checksum += digit * (int)Math.Pow(2, 8 - i);
            }

            // Calculates the remainder of the division by 11 and then by 10
            checksum %= 11;
            checksum %= 10;

            // Return true if the last digit matches the calculated checksum
            return lastDigit == checksum;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

