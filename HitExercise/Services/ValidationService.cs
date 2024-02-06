using HitExercise.Interfaces.Repositories;
using HitExercise.Interfaces.Services;
using HitExercise.Data;

namespace HitExercise.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ISupplierRepository _supplierRepository;

        public ValidationService( ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public bool IsNameUnique(string name)
        {
            return !_supplierRepository.ExistsWithName(name);

        }
        public bool IsEditableNameUnique(string name)
        {
            return !_supplierRepository.ExistsEditableName(name);
        }

        public bool IsAfmOk(string afm)
        {
            return _supplierRepository.isAfmValid(afm);
        }
             
    }
}
