using JetBrains.Annotations;
using Lykke.Service.Tiers.Client.Api;

namespace Lykke.Service.Tiers.Client
{
    /// <summary>
    /// Tiers service client.
    /// </summary>
    [PublicAPI]
    public interface ITiersClient
    {
        /// <summary>
        /// The customers API.
        /// </summary>
        ICustomersApi Customers { get; }

        /// <summary>
        /// The reports API.
        /// </summary>
        IReportsApi Reports { get; }

        /// <summary>
        /// The tiers API.
        /// </summary>
        ITiersApi Tiers { get; }
    }
}
