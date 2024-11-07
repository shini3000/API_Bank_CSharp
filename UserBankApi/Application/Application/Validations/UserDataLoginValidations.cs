
using Application.Dto;
using Application.Exceptions;
using System.Text.RegularExpressions;

namespace Application.Validations
{
    public class UserDataLoginValidations
    {
        public void Validate(LoginDto loginDto)
        {
            UserEmailValidate(loginDto.Email);
            UserPasswordValidate(loginDto.Password);
        }

        private void UserEmailValidate(string email) 
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new UserInvalidException("El campo Email no puede ser nulo o vacio");
            }
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                throw new UserInvalidException("El correo no es valido");
            }
        }

        private void UserPasswordValidate(string password) 
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new UserInvalidException("El campo Password no puede ser nulo o vacio");
            }
        }
    }
}
