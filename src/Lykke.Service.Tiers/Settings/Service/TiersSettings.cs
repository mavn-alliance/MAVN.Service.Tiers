using JetBrains.Annotations;
using Lykke.Service.Tiers.Settings.Service.Db;
using Lykke.Service.Tiers.Settings.Service.Rabbit;

namespace Lykke.Service.Tiers.Settings.Service
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class TiersSettings
    {
        public DbSettings Db { get; set; }

        public RabbitSettings Rabbit { get; set; }
    }
}
