using JetBrains.Annotations;
using MAVN.Service.Tiers.Settings.Service.Db;
using MAVN.Service.Tiers.Settings.Service.Rabbit;

namespace MAVN.Service.Tiers.Settings.Service
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class TiersSettings
    {
        public DbSettings Db { get; set; }

        public RabbitSettings Rabbit { get; set; }
    }
}
