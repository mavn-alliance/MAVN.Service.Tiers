using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.Tiers.Client.Models.Reports;
using Refit;

namespace Lykke.Service.Tiers.Client.Api
{
    /// <summary>
    /// Provides methods for work with reports.
    /// </summary>
    [PublicAPI]
    public interface IReportsApi
    {
        /// <summary>
        /// Returns the number of customers per reward tier.
        /// </summary>
        /// <returns>A collection of reward ties and number of customers associated with each one.</returns>
        [Get("/api/reports/numberOfCustomersPerTier")]
        Task<IReadOnlyList<TierCustomersCountModel>> GetNumberOfCustomersPerTierAsync();
    }
}
