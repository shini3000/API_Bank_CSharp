using Application;
using Application.Mapper;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using UserBankApi.Data;

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
            var connectionString = Configuration.GetConnectionString("ConnectionServer");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddApplicationInjection();
            services.AddInfrastructureInjection();
            services.AddDomainInjection();
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
