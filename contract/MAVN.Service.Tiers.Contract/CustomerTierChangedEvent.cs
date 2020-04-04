using System;

namespace MAVN.Service.Tiers.Contract
{
    /// <summary>
    /// Represents the event that occurs than customer reward tier change.
    /// </summary>
    public class CustomerTierChangedEvent
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CustomerTierChangedEvent"/>.
        /// </summary>
        public CustomerTierChangedEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CustomerTierChangedEvent"/> with parameters.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="tierId">The reward tier identifier.</param>
        public CustomerTierChangedEvent(Guid customerId, Guid tierId)
        {
            CustomerId = customerId;
            TierId = tierId;
        }

        /// <summary>
        /// The customer identifier.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The identifier of new reward tier associated with the customer.
        /// </summary>
        public Guid TierId { get; set; }
    }
}
