namespace HitExercise.Interfaces.Services
{
    public interface IValidationService
    {
        bool IsNameUnique(string name);
        bool IsEditableNameUnique(string name);
        public bool IsAfmOk(string afm);
    }
}
