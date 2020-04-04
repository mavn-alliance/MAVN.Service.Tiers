using JetBrains.Annotations;
using MAVN.Service.Tiers.Settings.Service.Rabbit.Publishers;
using MAVN.Service.Tiers.Settings.Service.Rabbit.Subscribers;

namespace MAVN.Service.Tiers.Settings.Service.Rabbit
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class RabbitSettings
    {
        public RabbitPublishers Publishers { get; set; }

        public RabbitSubscribers Subscribers { get; set; }
    }
}
