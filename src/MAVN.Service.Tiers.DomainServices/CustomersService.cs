using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Log;
using Falcon.Numerics;
using Lykke.Common.Log;
using Lykke.RabbitMqBroker.Publisher;
using Lykke.Service.CustomerProfile.Client;
using Lykke.Service.CustomerProfile.Client.Models.Enums;
using MAVN.Service.Tiers.Contract;
using MAVN.Service.Tiers.Domain.Entities;
using MAVN.Service.Tiers.Domain.Exceptions;
using MAVN.Service.Tiers.Domain.Repositories;
using MAVN.Service.Tiers.Domain.Services;

namespace MAVN.Service.Tiers.DomainServices
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomerTiersRepository _customerTiersRepository;
        private readonly ICustomerBonusesRepository _customerBonusesRepository;
        private readonly ITiersService _tiersService;
        private readonly IRabbitPublisher<CustomerTierChangedEvent> _customerTierChangedPublisher;
        private readonly ICustomerProfileClient _customerProfileClient;
        private readonly SemaphoreSlim _sync = new SemaphoreSlim(1, 1);
        private readonly ILog _log;

        public CustomersService(
            ICustomerTiersRepository customerTiersRepository,
            ICustomerBonusesRepository customerBonusesRepository,
            ITiersService tiersService,
            IRabbitPublisher<CustomerTierChangedEvent> customerTierChangedPublisher,
            ICustomerProfileClient customerProfileClient,
            ILogFactory logFactory)
        {
            _customerTiersRepository = customerTiersRepository;
            _customerBonusesRepository = customerBonusesRepository;
            _tiersService = tiersService;
            _customerTierChangedPublisher = customerTierChangedPublisher;
            _customerProfileClient = customerProfileClient;
            _log = logFactory.CreateLog(this);
        }

        public async Task AddAsync(Guid customerId)
        {
            try
            {
                await _sync.WaitAsync();

                var defaultTier = await _tiersService.GetDefaultAsync();

                if (defaultTier == null)
                    throw new FailedOperationException("Default tier not found.");

                var tierId = await _customerTiersRepository.GetTierByCustomerIdAsync(customerId);

                if (tierId.HasValue)
                    return;

                await _customerTiersRepository.InsertAsync(customerId, defaultTier.Id);

                _log.Info("Customer reward tier initialized",
                    context: $"customerId: {customerId}; tierId: {defaultTier.Id}");

                var evt = new CustomerTierChangedEvent(customerId, defaultTier.Id);
                await _customerTierChangedPublisher.PublishAsync(evt);

                _log.Info("Customer tier changed event published",
                    context: $"customerId: {customerId}, tierId: {tierId}");
            }
            finally
            {
                _sync.Release();
            }
        }

        public async Task UpdateAsync(Guid customerId, Money18 bonusAmount)
        {
            try
            {
                await _sync.WaitAsync();

                var customerBonuses = await _customerBonusesRepository.GetAsync(customerId);

                if (customerBonuses == null)
                {
                    customerBonuses = new CustomerBonuses
                    {
                        CustomerId = customerId,
                        TotalAwardedBonuses = bonusAmount
                    };

                    await _customerBonusesRepository.CreateAsync(customerBonuses);
                }
                else
                {
                    customerBonuses.TotalAwardedBonuses += bonusAmount;
                    
                    await _customerBonusesRepository.UpdateAsync(customerBonuses);
                }
                
                var tier = await _tiersService.GetByAmountAsync(customerBonuses.TotalAwardedBonuses);

                if (tier == null)
                    throw new FailedOperationException("No matching tier found.");

                var tierId = await _customerTiersRepository.GetTierByCustomerIdAsync(customerId);

                if (tierId.HasValue)
                {
                    if (tierId.Value == tier.Id)
                    {
                        _log.Info("Customer current tier corresponds to amount.");
                        return;
                    }

                    await _customerTiersRepository.UpdateAsync(customerId, tier.Id);
                }
                else
                {
                    await _customerTiersRepository.InsertAsync(customerId, tier.Id);
                }

                _log.Info("Customer reward tier updated",
                    context: $"customerId: {customerId}; tierId: {tier.Id}");

                var evt = new CustomerTierChangedEvent(customerId, tier.Id);
                await _customerTierChangedPublisher.PublishAsync(evt);

                _log.Info("Customer tier changed event published",
                    context: $"customerId: {customerId}, tierId: {tierId}");
            }
            finally
            {
                _sync.Release();
            }
        }

        public async Task<Tier> GetTierAsync(Guid customerId)
        {
            var tierId = await _customerTiersRepository.GetTierByCustomerIdAsync(customerId);

            if (tierId != null)
                return await _tiersService.GetByIdAsync(tierId.Value);
            
            var customer =
                await _customerProfileClient.CustomerProfiles.GetByCustomerIdAsync(customerId.ToString(), true);

            if (customer.ErrorCode == CustomerProfileErrorCodes.CustomerProfileDoesNotExist)
            {
                throw new FailedOperationException("Customer not found.");
            }

            return await _tiersService.GetByAmountAsync(0); // default tier.
        }
    }
}
