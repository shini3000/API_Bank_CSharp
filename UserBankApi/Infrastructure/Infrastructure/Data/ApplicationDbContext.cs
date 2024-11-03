using Microsoft.EntityFrameworkCore;
using UserBankApi.Models.Entities;

namespace UserBankApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<UserEntity>().Property(u => u.Balance).HasPrecision(18, 2);
        }
    }
}
