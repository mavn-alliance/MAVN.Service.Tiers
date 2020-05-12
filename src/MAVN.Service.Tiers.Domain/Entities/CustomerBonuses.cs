using System;
using MAVN.Numerics;

namespace MAVN.Service.Tiers.Domain.Entities
{
    public class CustomerBonuses
    {
        public Guid CustomerId { get; set; }
        
        public Money18 TotalAwardedBonuses { get; set; }
    }
}