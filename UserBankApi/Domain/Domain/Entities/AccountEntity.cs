using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using UserBankApi.Interfaces.Entity;

namespace UserBankApi.Models.Entities
{
    public class AccountEntity : BaseEntity
    {
        [Column(TypeName = "varchar(36)")]
        public int AccountNumber { get; set; }

        [Required]
        [ForeignKey("UserEntity")]
        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }

        [JsonIgnore]
        public ICollection<AccountActivityEntity> Activities { get; set; }
    }
}
