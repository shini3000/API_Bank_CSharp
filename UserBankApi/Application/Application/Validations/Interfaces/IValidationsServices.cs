
namespace Application.Validations.Interfaces
{
    public interface  IValidationsServices<T1,T2>
    {
        public void Validate(T1 value,T2 other);
    }
}
