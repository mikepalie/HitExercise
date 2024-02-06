using HitExercise.Models;

namespace HitExercise.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        object GetAll();
        Country GetById(int id);
    }
}
