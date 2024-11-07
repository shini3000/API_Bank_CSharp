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
        private readonly UserDataCreateValidation _userDataValidation;
        private readonly UserDataLoginValidations _userDataLoginValidation;

        public UserServices(IMapper mapper, UserRepository repository,
            UserDataCreateValidation userDataValidation, UserDataLoginValidations userDataLoginValidation)
        {
            _mapper = mapper;
            _repository = repository;
            _userDataValidation = userDataValidation;
            _userDataLoginValidation = userDataLoginValidation;
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
            _userDataValidation.Validate(userDto, _repository);
            var userEntity = _mapper.Map<UserEntity>(userDto);
            await _repository.SaveAsync(userEntity);
            userEntity.Password = null;
            return userEntity;
        }

        public Task<UserEntity> update(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyPassword(LoginDto loginDto)
        {
            _userDataLoginValidation.Validate(loginDto);
            var userEntity = await _repository.FindByEmail(loginDto.Email);

            if (userEntity == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(loginDto.Password, userEntity.Password);
        }

        public Task<UserEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
