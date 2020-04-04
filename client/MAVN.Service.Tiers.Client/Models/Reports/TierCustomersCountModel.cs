using System;
using Falcon.Numerics;
using JetBrains.Annotations;

namespace MAVN.Service.Tiers.Client.Models.Reports
{
    /// <summary>
    /// Represents the information of tier and number of customers associated with this tier.
    /// </summary>
    [PublicAPI]
    public class TierCustomersCountModel
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

        /// <summary>
        /// The of number of customers associated with this tier.
        /// </summary>
        public int CustomersCount { get; set; }
    }
}
