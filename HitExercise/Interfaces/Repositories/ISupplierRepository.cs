using HitExercise.Models;
using System.Collections.Generic;

namespace HitExercise.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();
        void Add(Supplier supplier);
        void Update(Supplier supplier); 
        void Delete(Supplier supplier);
        Supplier GetById(int id);
        bool ExistsWithName(string name);
        bool ExistsEditableName(string name);
        bool isAfmValid(string afmNumber);
        void Dispose();
        IEnumerable<Supplier> GetSuppliersByCategoryId(int id);
        IEnumerable<Supplier> GetSuppliersByCountryId(int id);
        IEnumerable<Supplier> GetSuppliersBySearching(string searchingString);
    }
}
