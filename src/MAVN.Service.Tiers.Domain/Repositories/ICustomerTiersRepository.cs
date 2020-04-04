using System;
using System.Threading.Tasks;

namespace MAVN.Service.Tiers.Domain.Repositories
{
    public interface ICustomerTiersRepository
    {
        Task<Guid?> GetTierByCustomerIdAsync(Guid customerId);

        Task<int> GetCustomerCountByTierId(Guid tierId);
        
        Task InsertAsync(Guid customerId, Guid tierId);
        
        Task UpdateAsync(Guid customerId, Guid tierId);
    }
}
