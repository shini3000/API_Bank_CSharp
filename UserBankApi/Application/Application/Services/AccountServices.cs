using Application.Dto;
using Application.Services.Interfaces;
using Application.Validations.Interfaces;
using AutoMapper;
using Domain.Generator;
using Infrastructure.Repository.Interfaces;
using UserBankApi.Models.Entities;

namespace Application.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository<AccountEntity> _accountRepository;
        private readonly IValidationsServices<AccountEntity, string> _getBalanceValidation;

        public AccountServices(IMapper mapper, IAccountRepository<AccountEntity> accountRepository,
            IValidationsServices<AccountEntity, string> getBalanceValidation)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _getBalanceValidation = getBalanceValidation;
        }

        public async Task<AccountEntity> CreateAccount(Account account)
        {
            AccountEntity accountEntity = _mapper.Map<AccountEntity>(account);
            accountEntity.AccountNumber = GeneratorNumberAccount.GenerateUniqueAccountNumber();
            return await _accountRepository.CreateAccount(accountEntity);
        }

        public async Task<List<AccountEntity>> GetAccountsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountEntity> GetAccountByAccountNumber(int accountNumber,string tokenUserId)
        {
            var account = await _accountRepository.GetAccountByAccountNumber(accountNumber);
            _getBalanceValidation.Validate(account, tokenUserId);
            return account;
        }

        public async Task<AccountEntity> UpdateAccount(int accountNumber)
        {
            return null;
        }
    }
}
