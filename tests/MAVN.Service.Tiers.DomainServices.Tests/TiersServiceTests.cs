using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAVN.Numerics;
using Lykke.Logs;
using MAVN.Service.Tiers.Domain.Entities;
using MAVN.Service.Tiers.Domain.Repositories;
using MAVN.Service.Tiers.Domain.Services;
using Moq;
using Xunit;

namespace MAVN.Service.Tiers.DomainServices.Tests
{
    public class TiersServiceTests
    {
        private const string BlackTierName = "Black";
        private const string SilverTierName = "Silver";
        private const string GoldTierName = "Gold";
        private const string PlatinumTierName = "Platinum";
        
        private readonly Mock<ITiersRepository> _tiersRepositoryMock =
            new Mock<ITiersRepository>();

        private readonly List<Tier> _tiers = new List<Tier>
        {
            new Tier(new Guid("e5538c22-3f19-489a-8eed-0549b84a47d2"), BlackTierName, new Money18(0, 0)),
            new Tier(new Guid("af3804ef-faf2-47b0-b6f6-66100f3bcdd4"), SilverTierName, new Money18(10000, 0)),
            new Tier(new Guid("df6e1941-0828-4424-9ed5-451d73139bed"), GoldTierName, new Money18(25000, 0)),
            new Tier(new Guid("4c3cd4ce-98eb-487d-bef8-7e0ee3801ecc"), PlatinumTierName, new Money18(60000, 0))
        };
        
        private readonly ITiersService _service;
        
        public TiersServiceTests()
        {
            _tiersRepositoryMock.Setup(o => o.GetAllAsync())
                .Returns(() => Task.FromResult<IReadOnlyList<Tier>>(_tiers.OrderBy(o => o.Name).ToList()));
            
            _service = new TiersService(_tiersRepositoryMock.Object, EmptyLogFactory.Instance);
        }

        [Fact]
        public async Task Returns_Default_Tier()
        {
            // act

            var tier = await _service.GetDefaultAsync();

            // assert
            
            Assert.Equal(tier.Name, BlackTierName);
        }
        
        [Fact]
        public async Task Returns_Tier_For_By_Amount()
        {
            // act

            var tier = await _service.GetByAmountAsync(new Money18(1000, 0));

            // assert
            
            Assert.Equal(tier.Name, BlackTierName);
        }
        
        [Fact]
        public async Task Returns_Tier_For_If_Amount_Equal_To_Threshold()
        {
            // act

            var tier = await _service.GetByAmountAsync(new Money18(10000, 0));

            // assert
            
            Assert.Equal(tier.Name, SilverTierName);
        }
        
        [Fact]
        public async Task Returns_Tier_For_Big_Amount()
        {
            // act

            var tier = await _service.GetByAmountAsync(int.MaxValue);

            // assert
            
            Assert.Equal(tier.Name, PlatinumTierName);
        }
    }
}
