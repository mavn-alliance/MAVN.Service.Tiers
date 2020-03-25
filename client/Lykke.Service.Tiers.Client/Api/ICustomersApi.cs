using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.Tiers.Client.Models.Tiers;
using Refit;

namespace Lykke.Service.Tiers.Client.Api
{
    /// <summary>
    /// Provides methods for work with customers reward tier.
    /// </summary>
    [PublicAPI]
    public interface ICustomersApi
    {
        /// <summary>
        /// Returns reward tier that associated with customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        /// <returns>The reward tier.</returns>
        [Get("/api/customers/{customerId}/tier")]
        Task<CustomerTierResponseModel> GetTierAsync(Guid customerId);
    }
}
