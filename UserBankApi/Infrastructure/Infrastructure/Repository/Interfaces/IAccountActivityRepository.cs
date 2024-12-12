
namespace Infrastructure.Repository.Interfaces
{
    public interface IAccountActivityRepository<T>
    {
        Task<T> CreateAccountActivity(T accountActivity);
        Task<T> GetAccountActivity(int accountNumber);
    }
}
