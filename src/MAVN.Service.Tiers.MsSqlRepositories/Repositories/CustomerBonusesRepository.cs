using System;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Common.MsSql;
using MAVN.Service.Tiers.Domain.Entities;
using MAVN.Service.Tiers.Domain.Repositories;
using MAVN.Service.Tiers.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.Tiers.MsSqlRepositories.Repositories
{
    public class CustomerBonusesRepository : ICustomerBonusesRepository
    {
        private readonly IMapper _mapper;
        private readonly MsSqlContextFactory<DataContext> _contextFactory;

        public CustomerBonusesRepository(
            MsSqlContextFactory<DataContext> contextFactory,
            IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }
        
        public async Task<CustomerBonuses> GetAsync(Guid customerId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.CustomerBonuses.SingleOrDefaultAsync(o => o.CustomerId == customerId);
                
                return _mapper.Map<CustomerBonuses>(entity);
            }
        }

        public async Task<CustomerBonuses> CreateAsync(CustomerBonuses customerBonuses)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = _mapper.Map<CustomerBonusesEntity>(customerBonuses);

                entity.Id = Guid.NewGuid();

                context.CustomerBonuses.Add(entity);

                await context.SaveChangesAsync();

                return customerBonuses;
            }
        }

        public async Task<CustomerBonuses> UpdateAsync(CustomerBonuses customerBonuses)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.CustomerBonuses.SingleOrDefaultAsync(o => o.CustomerId == customerBonuses.CustomerId);

                _mapper.Map(customerBonuses, entity);

                context.Update(entity);
                
                await context.SaveChangesAsync();

                return customerBonuses;
            }
        }
    }
}
