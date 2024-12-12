using UserBankApi.Interfaces.Dto;

namespace Application.Dto
{
    public class AccountActivityDto : BaseDto
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
