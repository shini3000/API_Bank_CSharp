using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using UserBankApi.Data;
using UserBankApi.Models.Entities;


namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository<UserEntity>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<UserEntity> _entities;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<UserEntity>();
        }

        public async Task<UserEntity> SaveAsync(UserEntity userEntity)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userEntity.Password);
            userEntity.Password = hashedPassword;
            _entities.Add(userEntity);
            await _context.SaveChangesAsync();
            return userEntity;
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            try { return await _entities.FirstOrDefaultAsync(x => x.Email == email); }
            catch (Exception) { }
            return null;
        }

        public Task<UserEntity> UpdateAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> DeleteAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}