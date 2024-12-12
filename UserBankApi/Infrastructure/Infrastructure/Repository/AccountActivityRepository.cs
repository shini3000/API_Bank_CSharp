using Infrastructure.Repository.Interfaces;
using UserBankApi.Models.Entities;

namespace Infrastructure.Repository
{
    public class AccountActivityRepository : IAccountActivityRepository<AccountActivityEntity>
    {
        public Task<AccountActivityEntity> CreateAccountActivity(int accountNumber, int accountNumberDestination, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<AccountActivityEntity> GetAccountActivity(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
