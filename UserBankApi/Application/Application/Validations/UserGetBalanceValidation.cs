
using Application.Exceptions;
using Application.Validations.Interfaces;

namespace Application.Validations
{
    public class UserGetBalanceValidation : IValidationsServices<string, string>
    {
        public void Validate(string email, string emailToken)
        {
            UserNotEmpty(email);
            UserNotOwner(email, emailToken);
        }

        private void UserNotEmpty(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new UserInvalidException("El campo Email no puede ser nulo o vacio");
            }
        }

        private void UserNotOwner(string email, string other)
        {
            if (email != other)
            {
                throw new UnauthorizedException("El usuario no es el propietario");
            }
        }
    }
}
