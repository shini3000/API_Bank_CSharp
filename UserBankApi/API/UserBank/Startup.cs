using Application.Mapper;
using Application.Validations;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using UserBankApi.Data;
using UserBankApi.Services;

namespace UserBankApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<UserServices>();
            services.AddScoped<UserRepository>();
            services.AddScoped<UserDataValidation>();

            var connectionString = Configuration.GetConnectionString("ConnectionServer");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString)));

            services.AddAutoMapper(typeof(MainMapper));
        }

        public void Configure(WebApplication app) 
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}