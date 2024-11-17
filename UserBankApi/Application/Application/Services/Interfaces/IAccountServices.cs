using Application.Dto;
using UserBankApi.Models.Entities;

namespace Application.Services.Interfaces
{
    public interface IAccountServices
    {
        Task<AccountEntity> CreateAccount(Account account);
        Task<List<AccountEntity>> GetAccountsByUser(int userId);
    }
}
