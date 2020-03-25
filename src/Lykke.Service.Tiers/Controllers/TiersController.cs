using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.Tiers.Client.Api;
using Lykke.Service.Tiers.Client.Models.Tiers;
using Lykke.Service.Tiers.Domain.Entities;
using Lykke.Service.Tiers.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.Tiers.Controllers
{
    [ApiController]
    [Route("api/tiers")]
    public class TiersController : ControllerBase, ITiersApi
    {
        private readonly ITiersService _tiersService;
        private readonly IMapper _mapper;

        public TiersController(ITiersService tiersService, IMapper mapper)
        {
            _tiersService = tiersService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all reward tiers.
        /// </summary>
        /// <returns>
        /// 200 - A collection of tiers.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<TierModel>), (int) HttpStatusCode.OK)]
        public async Task<IReadOnlyList<TierModel>> GetAllAsync()
        {
            var tiers = await _tiersService.GetAllAsync();

            return _mapper.Map<List<TierModel>>(tiers);
        }

        /// <summary>
        /// Returns the reward tier by identifier.
        /// </summary>
        /// <returns>
        /// 200 - The reward tier.
        /// </returns>
        [HttpGet("{tierId}")]
        [ProducesResponseType(typeof(IReadOnlyList<TierModel>), (int) HttpStatusCode.OK)]
        public async Task<TierModel> GetByIdAsync(Guid tierId)
        {
            var tier = await _tiersService.GetByIdAsync(tierId);

            return _mapper.Map<TierModel>(tier);
        }

        /// <summary>
        /// Updates reward tier.
        /// </summary>
        /// <param name="model">The model that represent reward tier.</param>
        /// <returns>
        /// 204 - The reward tier successfully updated.
        /// </returns>
        [HttpPut]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task UpdateAsync([FromBody] TierModel model)
        {
            var tier = _mapper.Map<Tier>(model);
            
            await _tiersService.UpdateAsync(tier);
        }
    }
}
