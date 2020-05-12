using System;
using MAVN.Numerics;
using JetBrains.Annotations;

namespace MAVN.Service.Tiers.Client.Models.Tiers
{
    /// <summary>
    /// Represents reward tier.
    /// </summary>
    [PublicAPI]
    public class TierModel
    {
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
