using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAVN.Numerics;

namespace MAVN.Service.Tiers.MsSqlRepositories.Entities
{
    [Table("tiers")]
    public class TierEntity
    {
        public TierEntity()
        {
        }

        public TierEntity(Guid id, string name, Money18 threshold)
        {
            Id = id;
            Name = name;
            Threshold = threshold;
        }
        
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column("threshold")]
        public Money18 Threshold { get; set; }
    }
}
