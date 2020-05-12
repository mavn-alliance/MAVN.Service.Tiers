using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Log;
using MAVN.Numerics;
using Lykke.Common.Log;
using MAVN.Service.Tiers.Domain.Entities;
using MAVN.Service.Tiers.Domain.Repositories;
using MAVN.Service.Tiers.Domain.Services;

namespace MAVN.Service.Tiers.DomainServices
{
    public class TiersService : ITiersService
    {
        private readonly ITiersRepository _tiersRepository;
        private readonly ILog _log;

        public TiersService(ITiersRepository tiersRepository, ILogFactory logFactory)
        {
            _tiersRepository = tiersRepository;
            _log = logFactory.CreateLog(this);
        }

        public Task<IReadOnlyList<Tier>> GetAllAsync()
        {
            return _tiersRepository.GetAllAsync();
        }

        public Task<Tier> GetByIdAsync(Guid tierId)
        {
            return _tiersRepository.GetByIdAsync(tierId);
        }

        public async Task<Tier> GetDefaultAsync()
        {
            var tiers = await _tiersRepository.GetAllAsync();

            return tiers.OrderBy(o => o.Threshold).FirstOrDefault();
        }

        public async Task<Tier> GetByAmountAsync(Money18 amount)
        {
            var tiers = await _tiersRepository.GetAllAsync();

            return tiers
                .Where(o => o.Threshold <= amount)
                .OrderByDescending(o => o.Threshold)
                .FirstOrDefault();
        }

        public async Task UpdateAsync(Tier tier)
        {
            if (await _tiersRepository.GetByIdAsync(tier.Id) == null)
                return;

            await _tiersRepository.UpdateAsync(tier);

            _log.Info("Tier updated", context: $"data: {tier.ToJson()}");
        }
    }
}
