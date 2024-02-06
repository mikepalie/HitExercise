using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
using HitExercise.Models;
using System.Linq;

namespace HitExercise.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public object GetAll()
        {
            var obj = new
            {
                Categories = _context.Categories.Select(c => new { c.CategoryId, c.Name })
            };
            return obj;
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }
             
    }
}
