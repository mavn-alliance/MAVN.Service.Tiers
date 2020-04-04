using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.Tiers.Domain.Entities;

namespace MAVN.Service.Tiers.Domain.Repositories
{
    public interface ITiersRepository
    {
        Task<IReadOnlyList<Tier>> GetAllAsync();
        
        Task<Tier> GetByIdAsync(Guid tierId);
        
        Task UpdateAsync(Tier tier);
    }
}
