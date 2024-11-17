
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using UserBankApi.Data;
using UserBankApi.Models.Entities;

namespace Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository<AccountEntity>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<AccountEntity> _entities;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<AccountEntity>();
        }

        public async Task<AccountEntity> CreateAccount(AccountEntity account)
        {
            _entities.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<AccountEntity> GetAccountByAccountNumber(int accountNumber)
        {
            return await _entities.FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
        }

        public Task<AccountEntity> UpdateAccount(AccountEntity account)
        {
            throw new NotImplementedException();
        }
    }
}
