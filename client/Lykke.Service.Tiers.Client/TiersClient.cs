using Lykke.HttpClientGenerator;
using Lykke.Service.Tiers.Client.Api;

namespace Lykke.Service.Tiers.Client
{
    /// <inheritdoc />
    public class TiersClient : ITiersClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TiersClient"/> with <param name="httpClientGenerator"></param>.
        /// </summary> 
        public TiersClient(IHttpClientGenerator httpClientGenerator)
        {
            Customers = httpClientGenerator.Generate<ICustomersApi>();
            Reports = httpClientGenerator.Generate<IReportsApi>();
            Tiers = httpClientGenerator.Generate<ITiersApi>();
        }

        /// <inheritdoc />
        public ICustomersApi Customers { get; }

        /// <inheritdoc />
        public IReportsApi Reports { get; }

        /// <inheritdoc />
        public ITiersApi Tiers { get; }
    }
}
