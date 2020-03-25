namespace Lykke.Service.Tiers.Client.Models.Tiers
{
    /// <summary>
    /// Represents possible errors for getting Customer's Tier
    /// </summary>
    public enum CustomerTierResponseErrorCode
    {
        /// <summary>
        /// No error
        /// </summary>
        None,
        /// <summary>
        /// Provided Customer could not be found
        /// </summary>
        CustomerNotFound
    }
}