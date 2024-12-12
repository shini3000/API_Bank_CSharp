using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using UserBankApi.Data;
using UserBankApi.Models.Entities;

namespace Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository<AccountEntity>
    {
        private readonly ApplicationDbContext _context;


        public AccountRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<AccountEntity> CreateAccount(AccountEntity account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<AccountEntity> GetAccountByAccountNumber(int accountNumber)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
        }

        public async Task TransferFunds(int sourceAccountNumber, int destinationAccountNumber, decimal amount)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var sourceAccount = await _context.Accounts
                    .AsTracking()
                    .FirstOrDefaultAsync(x => x.AccountNumber == sourceAccountNumber);
                var destinationAccount = await _context.Accounts
                    .AsTracking()
                    .FirstOrDefaultAsync(x => x.AccountNumber == destinationAccountNumber);

                if (sourceAccount == null || destinationAccount == null) 
                {
                    throw new InvalidOperationException();
                }

                sourceAccount.Balance -= amount;
                destinationAccount.Balance += amount;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw new InvalidOperationException("One or both accounts not found");
            }
        }
    }
}
