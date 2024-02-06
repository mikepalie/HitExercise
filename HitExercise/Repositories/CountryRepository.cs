using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
using HitExercise.Models;
using System.Linq;

namespace HitExercise.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;
        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public object GetAll()
        {
            var obj = new
            {
                Countries = _context.Countries.Select(c => new { c.CountryId, c.Name })
            };
            return obj;
        }

        public Country GetById(int id)
        {
            var country = _context.Countries.Find(id);
            return country;
        }
    }
}
