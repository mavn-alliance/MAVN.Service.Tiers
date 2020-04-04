using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.Tiers.Domain.Entities;

namespace MAVN.Service.Tiers.Domain.Services
{
    public interface IReportsService
    {
        Task<IReadOnlyList<TierCustomersCount>> GetNumberOfCustomersPerTierAsync();
    }
}
