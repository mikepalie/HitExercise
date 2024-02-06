using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
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
        public IEnumerable<Models.Supplier> GetAll()
        {
            var suppliers = _context.Suppliers.Include(s => s.Category).Include(s => s.Country).ToList();
            return suppliers;
        }

        public void Add(Models.Supplier newSupplier)
        {
            _context.Suppliers.Add(newSupplier);
            _context.SaveChanges();
        }
        public void Update(Models.Supplier newSupplier)
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

        public void Delete(Models.Supplier supplier)
        {
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
            }
            _context.SaveChanges();
        }


        public Models.Supplier GetById(int id)
        {
            Models.Supplier supplier = _context.Suppliers.Find(id);
            return supplier;
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
            // Check if the VAT number has the correct length
            if (afmNumber.Length != 9)
                return false;

            // Extract the last digit
            int lastDigit;
            if (!int.TryParse(afmNumber.Substring(8, 1), out lastDigit))
                return false;

            // Calculate the checksum
            int checksum = 0;
            for (int i = 0; i < 8; i++)
            {
                int digit;
                if (!int.TryParse(afmNumber.Substring(i, 1), out digit))
                    return false;

                checksum += digit * (int)Math.Pow(2, 8 - i);
            }

            // Calculate the remainder of the division by 11 and then by 10
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

