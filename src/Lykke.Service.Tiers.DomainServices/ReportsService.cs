using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Lykke.Service.Tiers.Domain.Entities;
using Lykke.Service.Tiers.Domain.Repositories;
using Lykke.Service.Tiers.Domain.Services;

namespace Lykke.Service.Tiers.DomainServices
{
    public class ReportsService : IReportsService
    {
        private readonly ICustomerTiersRepository _customerTiersRepository;
        private readonly ITiersRepository _tiersRepository;
        
        public ReportsService(
            ICustomerTiersRepository customerTiersRepository,
            ITiersRepository tiersRepository)
        {
            _customerTiersRepository = customerTiersRepository;
            _tiersRepository = tiersRepository;
        }
        
        public async Task<IReadOnlyList<TierCustomersCount>> GetNumberOfCustomersPerTierAsync()
        {
            var tiers = await _tiersRepository.GetAllAsync();

            var result = new List<TierCustomersCount>();
            
            foreach (var tier in tiers)
            {
                result.Add(new TierCustomersCount
                {
                    Id = tier.Id,
                    CustomersCount = await _customerTiersRepository.GetCustomerCountByTierId(tier.Id),
                    Name = tier.Name,
                    Threshold = tier.Threshold
                });
            }

            return result;
        }
    }
}
