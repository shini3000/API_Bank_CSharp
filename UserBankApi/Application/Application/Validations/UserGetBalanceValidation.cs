
using Application.Exceptions;
using Application.Validations.Interfaces;
using UserBankApi.Models.Entities;

namespace Application.Validations
{
    public class UserGetBalanceValidation : IValidationsServices<AccountEntity, string>
    {
        public void Validate(AccountEntity account, string tokenUserId)
        {
            if (!(account == null))
            {
                DataNotEmpty(account.AccountNumber.ToString());
                UserNotOwner(account.UserId.ToString(), tokenUserId);
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

        private void UserNotOwner(string Id, string TokenId)
        {
            if (Id != TokenId)
            {
                throw new UnauthorizedException("El usuario no es el propietario");
            }
        }
    }
}
