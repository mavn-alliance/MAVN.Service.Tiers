using System;
using System.Threading.Tasks;
using Lykke.Service.Tiers.Domain.Entities;

namespace Lykke.Service.Tiers.Domain.Repositories
{
    public interface ICustomerBonusesRepository
    {
        Task<CustomerBonuses> GetAsync(Guid customerId);
        Task<CustomerBonuses> CreateAsync(CustomerBonuses customerBonuses);
        Task<CustomerBonuses> UpdateAsync(CustomerBonuses customerBonuses);
    }
}