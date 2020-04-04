using Autofac;
using JetBrains.Annotations;
using Lykke.Common;
using Lykke.RabbitMqBroker.Publisher;
using Lykke.Sdk;
using Lykke.Service.CustomerProfile.Client;
using Lykke.SettingsReader;
using MAVN.Service.Tiers.Contract;
using MAVN.Service.Tiers.Rabbit.Subscribers;
using MAVN.Service.Tiers.Services;
using MAVN.Service.Tiers.Settings;

namespace MAVN.Service.Tiers
{
    [UsedImplicitly]
    public class AutofacModule : Module
    {
        private const string QueueName = "tiers";
        private const string CustomerTierChangedEventExchangeName = "lykke.bonus.customertierchanged";
        private const string BonusReceivedEventExchangeName = "lykke.wallet.bonusreceived";

        private readonly AppSettings _settings;

        public AutofacModule(IReloadingManager<AppSettings> appSettings)
        {
            _settings = appSettings.CurrentValue;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DomainServices.AutofacModule());

            builder.RegisterCustomerProfileClient(_settings.CustomerProfileServiceClient);

            builder.RegisterModule(
                new MsSqlRepositories.AutofacModule(_settings.TiersService.Db.DataConnectionString));

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>()
                .SingleInstance();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>()
                .AutoActivate()
                .SingleInstance();

            builder.RegisterJsonRabbitPublisher<CustomerTierChangedEvent>(
                _settings.TiersService.Rabbit.Publishers.CustomerTierChangedConnectionString,
                CustomerTierChangedEventExchangeName);

            builder.RegisterType<BonusReceivedSubscriber>()
                .As<IStartStop>()
                .SingleInstance()
                .WithParameter("connectionString", _settings.TiersService.Rabbit.Subscribers.BonusReceivedConnectionString)
                .WithParameter("exchangeName", BonusReceivedEventExchangeName)
                .WithParameter("queueName", QueueName);
        }
    }
}
