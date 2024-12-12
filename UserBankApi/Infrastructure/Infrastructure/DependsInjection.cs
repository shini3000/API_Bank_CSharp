using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using UserBankApi.Models.Entities;

namespace Infrastructure
{
    public static class DependsInjection
    {
        public static void AddInfrastructureInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository<UserEntity>, UserRepository>();
            services.AddScoped<IAccountRepository<AccountEntity>, AccountRepository>();
            services.AddScoped<IAccountActivityRepository<AccountActivityEntity>, AccountActivityRepository>();
        }
    }
}
