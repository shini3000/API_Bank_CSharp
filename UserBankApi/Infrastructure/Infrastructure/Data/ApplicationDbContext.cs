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
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<AccountActivityEntity> AccountActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de UserEntity
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(u => u.Id); // Id viene de BaseEntity
                entity.Property(u => u.Name).IsRequired();
                entity.Property(u => u.Lastname).IsRequired();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.Password).IsRequired();
            });

            // Configuración de AccountEntity
            modelBuilder.Entity<AccountEntity>(entity =>
            {
                entity.HasKey(a => a.Id); // Id viene de BaseEntity
                entity.Property(a => a.Balance)
                      .HasPrecision(18, 2)
                      .IsRequired();

                entity.HasOne(a => a.User)
                      .WithMany(u => u.Accounts)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de AccountActivityEntity
            modelBuilder.Entity<AccountActivityEntity>(entity =>
            {
                entity.HasKey(ac => ac.Id); // Id viene de BaseEntity
                entity.Property(ac => ac.Amount)
                      .HasPrecision(18, 2)
                      .IsRequired();

                entity.Property(ac => ac.Timestamp)
                      .IsRequired();

                entity.HasOne(ac => ac.Account)
                      .WithMany(a => a.Activities)
                      .HasForeignKey(ac => ac.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
