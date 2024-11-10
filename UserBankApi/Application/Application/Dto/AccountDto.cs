using UserBankApi.Interfaces.Dto;
using UserBankApi.Models.Dto;

namespace Application.Dto
{
     public class AccountDto : BaseDto
    {
        public Guid AccountNumber { get; set; }
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public UserDto User { get; set; }
        public ICollection<AccountActivityDto> Activities { get; set; }
    }
}
