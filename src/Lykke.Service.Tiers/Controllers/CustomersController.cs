using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.Tiers.Client.Api;
using Lykke.Service.Tiers.Client.Models.Tiers;
using Lykke.Service.Tiers.Domain.Exceptions;
using Lykke.Service.Tiers.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.Tiers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase, ICustomersApi
    {
        private readonly ICustomersService _customersService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomersService customersService, IMapper mapper)
        {
            _customersService = customersService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns reward tier that associated with customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        /// <returns>
        /// 200 - The reward tier.
        /// </returns>
        [HttpGet("{customerId}/tier")]
        [ProducesResponseType(typeof(CustomerTierResponseModel), (int) HttpStatusCode.OK)]
        public async Task<CustomerTierResponseModel> GetTierAsync(Guid customerId)
        {
            try
            {
                var tier = await _customersService.GetTierAsync(customerId);

                return new CustomerTierResponseModel
                {
                    ErrorCode = CustomerTierResponseErrorCode.None,
                    Tier = _mapper.Map<TierModel>(tier)
                };
            }
            catch (FailedOperationException)
            {
                return new CustomerTierResponseModel
                {
                    ErrorCode = CustomerTierResponseErrorCode.CustomerNotFound
                };
            }
        }
    }
}
