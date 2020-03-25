using JetBrains.Annotations;
using Lykke.Service.Tiers.Settings.Service.Rabbit.Publishers;
using Lykke.Service.Tiers.Settings.Service.Rabbit.Subscribers;

namespace Lykke.Service.Tiers.Settings.Service.Rabbit
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class RabbitSettings
    {
        public RabbitPublishers Publishers { get; set; }

        public RabbitSubscribers Subscribers { get; set; }
    }
}
