using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.Tiers.Settings.Service.Rabbit.Subscribers
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class RabbitSubscribers
    {
        [AmqpCheck]
        public string BonusReceivedConnectionString { get; set; }
    }
}
