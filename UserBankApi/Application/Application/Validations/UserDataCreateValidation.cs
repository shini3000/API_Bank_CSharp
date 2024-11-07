﻿using Application.Exceptions;
using Infrastructure.Repository;
using System.Text.RegularExpressions;
using UserBankApi.Models.Dto;

namespace Application.Validations
{
    public class UserDataCreateValidation
    {
        public void Validate(UserDto userDto, UserRepository repository )
        {
            UserExists(userDto.Email, repository);
            UserDataNotEmpty(userDto.Email, userDto.Password, userDto.Name);
            UserPasswordValidation(userDto.Password);
            UserEmailValidation(userDto.Email);
        }

        private void UserExists(string email, UserRepository repository) 
        {
            if (repository.FindByEmail(email) != null)
            {
                throw new UserInvalidException("Email vinculado a una cuenta existente");
            }
        }

        private void UserDataNotEmpty(string email, string password, string name)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name))
            {
                throw new UserInvalidException("El usuario no puede ser nulo o vacio");
            }
        }

        private void UserPasswordValidation(string password)
        {
            if (password.Length < 8)
            {
                throw new UserInvalidException("La contraseña debe tener al menos 8 caracteres");
            }

            if (!password.Any(char.IsDigit))
            {
                throw new UserInvalidException("La contraseña debe contener al menos un número");
            }

            if (!password.Any(char.IsLetter))
            {
                throw new UserInvalidException("La contraseña debe contener al menos una letra");
            }

            if (!password.Any(char.IsUpper))
            {
                throw new UserInvalidException("La contraseña debe contener al menos una letra mayúscula");
            }

            if (!password.Any(char.IsLower))
            {
                throw new UserInvalidException("La contraseña debe contener al menos una letra minúscula");
            }
        }

        private void UserEmailValidation(string email)
        {
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                throw new UserInvalidException("El correo no es válido");
            }
        }
    }
}