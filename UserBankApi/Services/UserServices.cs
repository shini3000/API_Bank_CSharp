using UserBankApi.Interfaces.Services;
using UserBankApi.Models.Dto;
using UserBankApi.Models.Entities;

namespace UserBankApi.Services
{
    public class UserServices : IUserServices
    {
        public Task<UserEntity> delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> save(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> update(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
