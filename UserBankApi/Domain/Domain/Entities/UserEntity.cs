﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using UserBankApi.Interfaces.Entity;

namespace UserBankApi.Models.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; }

        [JsonIgnore]
        public List<AccountEntity> Accounts { get; set; }
    }
}
