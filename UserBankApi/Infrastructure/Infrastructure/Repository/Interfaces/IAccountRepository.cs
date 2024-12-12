
using UserBankApi.Models.Entities;

namespace Infrastructure.Repository.Interfaces
{
    public interface IAccountRepository<T>
    {
        Task<T> CreateAccount(T account);
        Task<T> GetAccountByAccountNumber(int accountNumber);
        Task<T> GetAccountByAccountId(Guid accountId);
        Task TransferFunds(int sourceAccountNumber, int destinationAccountNumber, decimal amount);
    }
}
