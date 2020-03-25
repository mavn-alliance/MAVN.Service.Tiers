using AutoMapper;
using Lykke.Service.Tiers.Domain.Entities;
using Lykke.Service.Tiers.MsSqlRepositories.Entities;

namespace Lykke.Service.Tiers.MsSqlRepositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tier, TierEntity>(MemberList.Source);
            CreateMap<TierEntity, Tier>(MemberList.Destination);
            
            CreateMap<CustomerBonusesEntity, CustomerBonuses>(MemberList.Destination);
            CreateMap<CustomerBonuses, CustomerBonusesEntity>(MemberList.Source);
        }
    }
}
