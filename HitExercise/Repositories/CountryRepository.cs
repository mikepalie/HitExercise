using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
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
    }
}
