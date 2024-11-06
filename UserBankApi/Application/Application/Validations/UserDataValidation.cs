
using Application.Exceptions;
using UserBankApi.Models.Dto;

namespace Application.Validations
{
    public class UserDataValidation
    {
        public void Validate(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new UserInvalidException("El usuario no puede ser nulo o vacio");
            }

            if (userDto.Email == "")
            {
                throw new UserInvalidException("El usuario no puede ser nulo o vacio");
            }
        }
    }
}
