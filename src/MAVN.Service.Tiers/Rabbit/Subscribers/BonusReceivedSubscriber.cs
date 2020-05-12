using System;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using Lykke.RabbitMqBroker.Subscriber;
using MAVN.Service.WalletManagement.Contract.Events;
using MAVN.Service.Tiers.Domain.Services;

namespace MAVN.Service.Tiers.Rabbit.Subscribers
{
    public class BonusReceivedSubscriber : JsonRabbitSubscriber<BonusReceivedEvent>
    {
        private readonly ICustomersService _customersService;
        private readonly ILog _log;

        public BonusReceivedSubscriber(
            string connectionString,
            string exchangeName,
            string queueName,
            ICustomersService customersService,
            ILogFactory logFactory)
            : base(connectionString, exchangeName, queueName, true, logFactory)
        {
            _customersService = customersService;
            _log = logFactory.CreateLog(this);
        }

        protected override async Task ProcessMessageAsync(BonusReceivedEvent message)
        {
            if (!Guid.TryParse(message.CustomerId, out var customerId))
            {
                _log.Warning("Invalid customer identifier", context: $"customerId: {message.CustomerId}");
                return;
            }

            try
            {
                await _customersService.UpdateAsync(customerId, message.Amount);
            }
            catch (Exception exception)
            {
                _log.Error(exception, context: $"customerId: {message.CustomerId}");
            }

            _log.Info("Customer bonus received event handled.", context: $"customerId: {message.CustomerId}");
        }
    }
}
