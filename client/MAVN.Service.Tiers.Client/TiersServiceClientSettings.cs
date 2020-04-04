using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.Tiers.Client
{
    /// <summary>
    /// Tiers client settings.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class TiersServiceClientSettings
    {
        /// <summary>
        /// Service url.
        /// </summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl { get; set; }
    }
}
