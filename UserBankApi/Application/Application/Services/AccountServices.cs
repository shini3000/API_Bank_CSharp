using Application.Dto;
using Application.Services.Interfaces;
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

        public AccountServices(IMapper mapper, IAccountRepository<AccountEntity> accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
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
    }
}
