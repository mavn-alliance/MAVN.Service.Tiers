using System;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Common.MsSql;
using Lykke.Service.Tiers.Domain.Repositories;
using Lykke.Service.Tiers.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lykke.Service.Tiers.MsSqlRepositories.Repositories
{
    public class CustomerTiersRepository : ICustomerTiersRepository
    {
        private readonly MsSqlContextFactory<DataContext> _contextFactory;

        public CustomerTiersRepository(MsSqlContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Guid?> GetTierByCustomerIdAsync(Guid customerId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.CustomerTiers.FirstOrDefaultAsync(o => o.CustomerId == customerId);

                return entity?.TierId;
            }
        }

        public async Task<int> GetCustomerCountByTierId(Guid tierId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var count = await context.CustomerTiers.Where(x => x.TierId == tierId).CountAsync();

                return count;
            }
        }

        public async Task InsertAsync(Guid customerId, Guid tierId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                context.CustomerTiers.Add(new CustomerTierEntity {CustomerId = customerId, TierId = tierId});

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Guid customerId, Guid tierId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.CustomerTiers.SingleOrDefaultAsync(o => o.CustomerId == customerId);

                if (entity == null)
                    return;

                entity.TierId = tierId;

                await context.SaveChangesAsync();
            }
        }
    }
}
