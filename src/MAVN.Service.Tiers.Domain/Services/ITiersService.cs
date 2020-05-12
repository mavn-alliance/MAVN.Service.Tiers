using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Numerics;
using MAVN.Service.Tiers.Domain.Entities;

namespace MAVN.Service.Tiers.Domain.Services
{
    public interface ITiersService
    {
        Task<IReadOnlyList<Tier>> GetAllAsync();

        Task<Tier> GetByIdAsync(Guid tierId);

        Task<Tier> GetDefaultAsync();

        Task<Tier> GetByAmountAsync(Money18 amount);

        Task UpdateAsync(Tier tier);
    }
}
