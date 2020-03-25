using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.Tiers.Settings.Service.Rabbit.Publishers
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class RabbitPublishers
    {
        [AmqpCheck]
        public string CustomerTierChangedConnectionString { get; set; }
    }
}
