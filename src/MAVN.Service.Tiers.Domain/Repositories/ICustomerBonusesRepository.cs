using System;
using System.Threading.Tasks;
using MAVN.Service.Tiers.Domain.Entities;

namespace MAVN.Service.Tiers.Domain.Repositories
{
    public interface ICustomerBonusesRepository
    {
        Task<CustomerBonuses> GetAsync(Guid customerId);
        Task<CustomerBonuses> CreateAsync(CustomerBonuses customerBonuses);
        Task<CustomerBonuses> UpdateAsync(CustomerBonuses customerBonuses);
    }
}