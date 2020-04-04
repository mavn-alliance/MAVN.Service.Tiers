using JetBrains.Annotations;
using Lykke.Sdk.Settings;
using Lykke.Service.CustomerProfile.Client;
using MAVN.Service.Tiers.Settings.Service;

namespace MAVN.Service.Tiers.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public TiersSettings TiersService { get; set; }
        
        public CustomerProfileServiceClientSettings CustomerProfileServiceClient { get; set; }
    }
}
