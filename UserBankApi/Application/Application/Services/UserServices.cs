using UserBankApi.Models.Dto;
using UserBankApi.Models.Entities;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.Repository.Interfaces;
using Domain.Interfaces.Dtos;
using Application.Validations.Interfaces;
using Domain.Interfaces;
using Application.Dto;


namespace UserBankApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository<UserEntity> _userRepository;
        private readonly IValidationsServices<UserDto, IUserRepository<UserEntity>> _userDataValidation;
        private readonly IValidationsServices<LoginDto, object> _userDataLoginValidation;
        private readonly IValidationsServices<string, string> _userGetBalanceValidation;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserServices(
            IUserRepository<UserEntity> userRepository,
            IValidationsServices<UserDto, IUserRepository<UserEntity>> userDataValidation,
            IValidationsServices<LoginDto, object> userDataLoginValidation,
            IValidationsServices<string, string> userGetBalanceValidation,
            IMapper mapper,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _userDataValidation = userDataValidation;
            _userDataLoginValidation = userDataLoginValidation;
            _userGetBalanceValidation = userGetBalanceValidation;
            _mapper = mapper;
            _tokenService = tokenService;
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

        public async Task<LoginResponse> VerifyPassword(LoginDto loginDto)
        {
            _userDataLoginValidation.Validate(loginDto, new object());
            var userEntity = await _userRepository.FindByEmail(loginDto.Email);
            if (userEntity == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, userEntity.Password))
            {
                return null;
            }

            var token = _tokenService.GenerateToken(userEntity);

            return new LoginResponse
            {
                Token = token
            };
        }

        public Task<UserEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetBalance(string email,string emailToken)
        {
            _userGetBalanceValidation.Validate(email, emailToken);
            UserEntity userEntity = await _userRepository.FindByEmail(email);
            userEntity.Password = null;
            return userEntity;  
        }
    }
}
