
using UserBankApi.Models.Entities;

namespace Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserEntity user);
    }
}
