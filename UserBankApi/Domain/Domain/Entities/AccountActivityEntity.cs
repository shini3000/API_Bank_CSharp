using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using UserBankApi.Interfaces.Entity;

namespace UserBankApi.Models.Entities
{
    public class AccountActivityEntity : BaseEntity
    {
        [Required]
        [ForeignKey("AccountEntity")]
        public Guid AccountId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public AccountEntity Account { get; set; }
    }
}
