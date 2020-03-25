namespace Lykke.Service.Tiers.Client.Models.Tiers
{
    /// <summary>
    /// Represents response from Tiers Service
    /// </summary>
    public class CustomerTierResponseModel
    {
        /// <summary>
        /// Error code for the request
        /// </summary>
        public CustomerTierResponseErrorCode ErrorCode { set; get; }
        
        /// <summary>
        /// Customer Tier, if no Error occured
        /// </summary>
        public TierModel Tier { set; get; }
    }
}