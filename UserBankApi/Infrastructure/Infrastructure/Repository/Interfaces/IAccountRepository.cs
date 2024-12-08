
namespace Infrastructure.Repository.Interfaces
{
    public interface IAccountRepository<T>
    {
        Task<T> CreateAccount(T account);
        Task<T> GetAccountByAccountNumber(int accountNumber);
        Task TransferFunds(int sourceAccountNumber, int destinationAccountNumber, decimal amount);
    }
}
