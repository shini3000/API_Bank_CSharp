
namespace Infrastructure.Repository.Interfaces
{
    public interface IAccountActivityRepository<T>
    {
        Task<T> CreateAccountActivity(T accountActivity);
        Task<List<T>> GetAccountActivity(int accountNumber);
    }
}
