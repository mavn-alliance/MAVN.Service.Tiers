using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Falcon.Numerics;

namespace Lykke.Service.Tiers.MsSqlRepositories.Entities
{
    [Table("customer_bonuses")]
    public class CustomerBonusesEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        [Column("total_awarded_bonuses")]
        public Money18 TotalAwardedBonuses { get; set; }
    }
}