

using Application.Exceptions;
using Application.Validations.Interfaces;
using UserBankApi.Models.Entities;

namespace Application.Validations
{
    public class OwnerUserValidate : IValidationsServices<string, AccountEntity, object>
    {
        public void Validate(string value, AccountEntity account, object valueNull)
        {
            UserNotOwner(account.UserId.ToString(), value);
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
