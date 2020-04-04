using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MAVN.Service.Tiers.Client.Models.Tiers;
using Refit;

namespace MAVN.Service.Tiers.Client.Api
{
    /// <summary>
    /// Provides methods for work with tiers.
    /// </summary>
    [PublicAPI]
    public interface ITiersApi
    {
        /// <summary>
        /// Returns all reward tiers.
        /// </summary>
        /// <returns>A collection of tiers.</returns>
        [Get("/api/tiers")]
        Task<IReadOnlyList<TierModel>> GetAllAsync();

        /// <summary>
        /// Returns the reward tier by identifier.
        /// </summary>
        /// <param name="tierId">The tier identifier.</param>
        /// <returns>The reward tier.</returns>
        [Get("/api/tiers/{tierId}")]
        Task<TierModel> GetByIdAsync(Guid tierId);

        /// <summary>
        /// Updates reward tier. 
        /// </summary>
        /// <param name="model">The model that represent reward tier.</param>
        [Put("/api/tiers")]
        Task UpdateAsync([Body] TierModel model);
    }
}
