using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Falcon.Numerics;
using Lykke.Service.Tiers.Domain.Entities;

namespace Lykke.Service.Tiers.Domain.Services
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
