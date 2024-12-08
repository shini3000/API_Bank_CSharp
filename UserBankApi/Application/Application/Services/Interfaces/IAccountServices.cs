using Application.Dto;
using UserBankApi.Models.Entities;

namespace Application.Services.Interfaces
{
    public interface IAccountServices
    {
        Task<AccountEntity> CreateAccount(Account account);
        Task<List<AccountEntity>> GetAccountsByUser(int userId);
        Task<AccountEntity> GetAccountByAccountNumber(int accountNumber, string userId);
        Task UpdateAccount(DepositDto depositDto);
    }
}
