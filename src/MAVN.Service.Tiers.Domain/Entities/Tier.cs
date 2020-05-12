using System;
using MAVN.Numerics;

namespace MAVN.Service.Tiers.Domain.Entities
{
    /// <summary>
    /// Represents reward tier.
    /// </summary>
    public class Tier
    {
        public Tier()
        {
        }

        public Tier(Guid id, string name, Money18 threshold)
        {
            Id = id;
            Name = name;
            Threshold = threshold;
        }
        
        /// <summary>
        /// The unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The tier display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The minimum amount of tokens required for this reward tier.
        /// </summary>
        public Money18 Threshold { get; set; }
    }
}
