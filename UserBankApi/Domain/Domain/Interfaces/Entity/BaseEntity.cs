using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserBankApi.Interfaces.Entity
{
    public class BaseEntity
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
