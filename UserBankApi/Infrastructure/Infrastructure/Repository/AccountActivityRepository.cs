using Infrastructure.Repository.Interfaces;
using System.Security.Principal;
using UserBankApi.Data;
using UserBankApi.Models.Entities;

namespace Infrastructure.Repository
{
    public class AccountActivityRepository : IAccountActivityRepository<AccountActivityEntity>
    {
        private readonly ApplicationDbContext _context;

        public AccountActivityRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<AccountActivityEntity> CreateAccountActivity(AccountActivityEntity accountActivityEntity)
        {
            _context.AccountActivities.Add(accountActivityEntity);
            await _context.SaveChangesAsync();
            return accountActivityEntity;
        }

        public Task<AccountActivityEntity> GetAccountActivity(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
