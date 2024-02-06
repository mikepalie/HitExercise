using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
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

    }
}
