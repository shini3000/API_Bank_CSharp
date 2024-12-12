using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<AccountActivityEntity>> GetAccountActivity(int accountNumber)
        {
            return await _context.AccountActivities
                .Where(x => x.Account.AccountNumber == accountNumber)
                .ToListAsync();
        }
    }
}
