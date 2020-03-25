using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.Tiers.Domain.Entities;

namespace Lykke.Service.Tiers.Domain.Services
{
    public interface IReportsService
    {
        Task<IReadOnlyList<TierCustomersCount>> GetNumberOfCustomersPerTierAsync();
    }
}
