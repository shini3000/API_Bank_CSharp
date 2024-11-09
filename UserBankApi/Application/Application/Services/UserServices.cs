using UserBankApi.Models.Dto;
using UserBankApi.Models.Entities;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.Repository.Interfaces;
using Application.Dto;
using Application.Validations.Interfaces;

namespace UserBankApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository<UserEntity> _userRepository;
        private readonly IValidationsServices<UserDto, IUserRepository<UserEntity>> _userDataValidation;
        private readonly IValidationsServices<LoginDto, object> _userDataLoginValidation;
        private readonly IMapper _mapper;

        public UserServices(
            IUserRepository<UserEntity> userRepository,
            IValidationsServices<UserDto, IUserRepository<UserEntity>> userDataValidation,
            IValidationsServices<LoginDto, object> userDataLoginValidation,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userDataValidation = userDataValidation;
            _userDataLoginValidation = userDataLoginValidation;
            _mapper = mapper;
        }

        public Task<UserEntity> delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            return await _userRepository.FindByEmail(email);
        }

       public async Task<UserEntity> save(UserDto userDto)
        {
        _userDataValidation.Validate(userDto, _userRepository);
        var userEntity = _mapper.Map<UserEntity>(userDto);
        await _userRepository.SaveAsync(userEntity);
        userEntity.Password = null;
        return userEntity;
        }

        public Task<UserEntity> update(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyPassword(LoginDto loginDto)
        {
            object obj = new object();
            _userDataLoginValidation.Validate(loginDto, obj);
            var userEntity = await _userRepository.FindByEmail(loginDto.Email);
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
