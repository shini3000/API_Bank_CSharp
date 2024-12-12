
namespace Infrastructure.Repository.Interfaces
{
    public interface IAccountActivityRepository<T>
    {
        Task<T> CreateAccountActivity(int accountNumber, int accountNumberDestination, int amount);
        Task<T> GetAccountActivity(int accountNumber);
    }
}
