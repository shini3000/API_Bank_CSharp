using UserBankApi.Models.Dto;
using UserBankApi.Models.Entities;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.Repository;
using Application.Dto;
using Application.Validations;

namespace UserBankApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _repository;
        private readonly UserDataValidation _userDataValidation;

        public UserServices(IMapper mapper, UserRepository repository,
            UserDataValidation userDataValidation)
        {
            _mapper = mapper;
            _repository = repository;
            _userDataValidation = userDataValidation;
        }

        public Task<UserEntity> delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            return await _repository.FindByEmail(email);
        }

        public async Task<UserEntity> save(UserDto userDto)
        {
            _userDataValidation.Validate(userDto);
            var userEntity = _mapper.Map<UserEntity>(userDto);
            await _repository.SaveAsync(userEntity);
            return userEntity;
        }

        public Task<UserEntity> update(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyPassword(string email, string inputPassword)
        {
            var userEntity = await _repository.FindByEmail(email);

            if (userEntity == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(inputPassword, userEntity.Password);
        }

        public Task<UserEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
