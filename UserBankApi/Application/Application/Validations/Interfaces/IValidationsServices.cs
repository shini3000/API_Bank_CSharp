
namespace Application.Validations.Interfaces
{
    public interface  IValidationsServices<T1,T2,T3>
    {
        public void Validate(T1 value,T2 value2,T3 value3);
    }
}
