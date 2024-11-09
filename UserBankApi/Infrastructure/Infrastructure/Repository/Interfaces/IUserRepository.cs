
namespace Infrastructure.Repository.Interfaces
{
    public interface IUserRepository<T>
    {
        public Task<T> SaveAsync(T user);
        public Task<T> UpdateAsync(T user);
        public Task<T> DeleteAsync(T user);
        public Task<T> GetByIdAsync(int id);
        public Task<T> FindByEmail(string email);
    }
}
