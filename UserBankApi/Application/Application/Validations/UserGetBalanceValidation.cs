
using Application.Exceptions;
using Application.Validations.Interfaces;
using UserBankApi.Models.Entities;

namespace Application.Validations
{
    public class UserGetBalanceValidation : IValidationsServices<AccountEntity, string,object>
    {
        public void Validate(AccountEntity account, string tokenUserId, object value)
        {
            if (!(account == null))
            {
                DataNotEmpty(account.AccountNumber.ToString());
            }
            else 
            {
                throw new NotFoundException("Cuenta no encontrada");
            }
            
        }

        private void DataNotEmpty(string accountNumber)
        {
            if (accountNumber.Length < 9 || accountNumber.Length >= 10)
            {
                throw new UserInvalidException("El numero de cuenta es invalido");
            }
        }
    }
}
