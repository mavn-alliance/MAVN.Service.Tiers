using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MAVN.Service.Tiers.Client.Api;
using MAVN.Service.Tiers.Client.Models.Reports;
using MAVN.Service.Tiers.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.Tiers.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase, IReportsApi
    {
        private readonly IReportsService _reportsService;
        private readonly IMapper _mapper;

        public ReportsController(IReportsService reportsService, IMapper mapper)
        {
            _reportsService = reportsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns the number of customers per reward tier.
        /// </summary>
        /// <returns>
        /// 200 - A collection of reward ties and number of customers associated with each one.
        /// </returns>
        [HttpGet("numberOfCustomersPerTier")]
        [ProducesResponseType(typeof(IReadOnlyList<TierCustomersCountModel>), (int) HttpStatusCode.OK)]
        public async Task<IReadOnlyList<TierCustomersCountModel>> GetNumberOfCustomersPerTierAsync()
        {
            var items = await _reportsService.GetNumberOfCustomersPerTierAsync();

            return _mapper.Map<List<TierCustomersCountModel>>(items);
        }
    }
}
