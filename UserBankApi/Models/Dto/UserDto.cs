using UserBankApi.Interfaces.Dto;

namespace UserBankApi.Models.Dto
{
    public class UserDto : BaseDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal Balance { get; set; }
    }
}