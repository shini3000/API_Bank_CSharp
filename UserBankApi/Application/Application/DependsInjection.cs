﻿using Application.Dto;
using Application.Mapper;
using Application.Services;
using Application.Services.Interfaces;
using Application.Validations;
using Application.Validations.Interfaces;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using UserBankApi.Models.Dto;
using UserBankApi.Models.Entities;
using UserBankApi.Services;

namespace Application
{
    public static class DependsInjection
    {
        public static void AddApplicationInjection(this IServiceCollection services)
        {
            services.AddScoped<IValidationsServices<UserDto, IUserRepository<UserEntity>, object>, UserDataCreateValidation>();
            services.AddScoped<IValidationsServices<LoginDto, object, object>, UserDataLoginValidations<object>>();
            services.AddScoped<IValidationsServices<AccountEntity, string, object>, UserGetBalanceValidation>();
            services.AddScoped<IValidationsServices<AccountEntity,AccountEntity,decimal>, TransactionsValidation>();
            services.AddScoped<IValidationsServices<string,AccountEntity,object>, OwnerUserValidate>();

            services.AddScoped<IUserServices,UserServices>();
            services.AddScoped<IAccountServices,AccountServices>();
            services.AddAutoMapper(typeof(MainMapper));
        }
    }
}
