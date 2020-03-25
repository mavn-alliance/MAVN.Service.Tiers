using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.Tiers.Domain.Entities;

namespace Lykke.Service.Tiers.Domain.Repositories
{
    public interface ITiersRepository
    {
        Task<IReadOnlyList<Tier>> GetAllAsync();
        
        Task<Tier> GetByIdAsync(Guid tierId);
        
        Task UpdateAsync(Tier tier);
    }
}
