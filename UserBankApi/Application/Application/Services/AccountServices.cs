using Application.Dto;
using Application.Services.Interfaces;
using Application.Validations.Interfaces;
using AutoMapper;
using Domain.Generator;
using Infrastructure.Repository.Interfaces;
using System.Data;
using UserBankApi.Models.Entities;

namespace Application.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository<AccountEntity> _accountRepository;
        private readonly IAccountActivityRepository<AccountActivityEntity> _accountActivityRepository;
        private readonly IValidationsServices<AccountEntity, string,object> _getBalanceValidation;
        private readonly IValidationsServices<AccountEntity, AccountEntity,decimal>  _trasactionValidation;
        private readonly IValidationsServices<string, AccountEntity, object> _OwnerUserValidate;

        public AccountServices(IMapper mapper, IAccountRepository<AccountEntity> accountRepository,
            IAccountActivityRepository<AccountActivityEntity> accountActivityRepository,
            IValidationsServices<AccountEntity, string, object> getBalanceValidation,
            IValidationsServices<AccountEntity,AccountEntity,decimal> trasactionValidation,
            IValidationsServices<string,AccountEntity,object> OwnerUserValidate)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountActivityRepository = accountActivityRepository;
            _getBalanceValidation = getBalanceValidation;
            _trasactionValidation = trasactionValidation;
            _OwnerUserValidate = OwnerUserValidate;
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
            _getBalanceValidation.Validate(account, tokenUserId, null);
            _OwnerUserValidate.Validate(tokenUserId, account, null);
            return account;
        }

        public async Task UpdateAccount(DepositDto depositDto, string tokenUserId)
        {
            var account = await _accountRepository.GetAccountByAccountNumber(depositDto.AccountNumber);
            var accountDestination = await _accountRepository.GetAccountByAccountNumber(depositDto.DestinationAccountNumber);
            _trasactionValidation.Validate(account, accountDestination, depositDto.Amount);
            _OwnerUserValidate.Validate(tokenUserId , account, null);
            await _accountRepository.TransferFunds(depositDto.AccountNumber, depositDto.DestinationAccountNumber, depositDto.Amount);
            var accountActivityDto = new AccountActivityDto
            {
                AccountId = account.Id,
                Amount = depositDto.Amount,
                Timestamp = DateTime.UtcNow
            };
            var accountActivityEntity = _mapper.Map<AccountActivityEntity>(accountActivityDto);
            await _accountActivityRepository.CreateAccountActivity(accountActivityEntity);
        }
    }
}
