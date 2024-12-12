
using Application.Exceptions;
using Application.Validations.Interfaces;
using UserBankApi.Models.Entities;

namespace Application.Validations
{
    public class TransactionsValidation : IValidationsServices<AccountEntity, AccountEntity, decimal>
    {
        public void Validate(AccountEntity account, AccountEntity accountDestionation,decimal amount)
        {
            existAccount(account, accountDestionation);
            amountValidate(amount, account);
        }

        private void amountValidate(decimal amount, AccountEntity account)
        {
            if (account.Balance <= amount)
            {
                throw new UserInvalidException("No hay suficiente dinero en la cuenta");
            }
        }

        private void existAccount(AccountEntity account, AccountEntity accountDestionation)
        {
            if (account == null || accountDestionation == null)
            {
                throw new NotFoundException("Cuenta no encontrada");
            }
        }
    }
}
