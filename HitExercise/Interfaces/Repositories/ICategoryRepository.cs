using HitExercise.Models;

namespace HitExercise.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        object GetAll();
        Category GetById(int id);
    }
}
