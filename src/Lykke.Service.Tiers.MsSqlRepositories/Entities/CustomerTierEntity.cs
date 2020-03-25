using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Falcon.Numerics;

namespace Lykke.Service.Tiers.MsSqlRepositories.Entities
{
    [Table("customer_tiers")]
    public class CustomerTierEntity
    {
        [Key]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        [Column("tier_id")]
        public Guid TierId { get; set; }
    }
}
