using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MAVN.Common.MsSql;
using MAVN.Service.Tiers.Domain.Entities;
using MAVN.Service.Tiers.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.Tiers.MsSqlRepositories.Repositories
{
    public class TiersRepository : ITiersRepository
    {
        private readonly MsSqlContextFactory<DataContext> _contextFactory;
        private readonly IMapper _mapper;

        public TiersRepository(MsSqlContextFactory<DataContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Tier>> GetAllAsync()
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entities = await context.Tiers.ToListAsync();

                return _mapper.Map<List<Tier>>(entities);
            }
        }

        public async Task<Tier> GetByIdAsync(Guid tierId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.Tiers.FirstOrDefaultAsync(o => o.Id == tierId);

                return _mapper.Map<Tier>(entity);
            }
        }

        public async Task UpdateAsync(Tier tier)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.Tiers.FirstOrDefaultAsync(o => o.Id == tier.Id);

                if (entity == null)
                    return;

                _mapper.Map(tier, entity);

                await context.SaveChangesAsync();
            }
        }
    }
}
