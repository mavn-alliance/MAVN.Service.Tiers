using System;
using System.Threading.Tasks;
using Falcon.Numerics;
using Lykke.Service.Tiers.Domain.Entities;

namespace Lykke.Service.Tiers.Domain.Services
{
    public interface ICustomersService
    {
        Task AddAsync(Guid customerId);

        Task UpdateAsync(Guid customerId, Money18 bonusAmount);

        Task<Tier> GetTierAsync(Guid customerId);
    }
}
