using JetBrains.Annotations;
using MAVN.Service.Tiers.Client.Api;

namespace MAVN.Service.Tiers.Client
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
