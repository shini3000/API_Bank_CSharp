using Application.Dto;
using Application.Mapper;
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
            services.AddScoped<IValidationsServices<UserDto, IUserRepository<UserEntity>>, UserDataCreateValidation>();
            services.AddScoped<IValidationsServices<LoginDto, object>, UserDataLoginValidations<object>>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddAutoMapper(typeof(MainMapper));
        }
    }
}
