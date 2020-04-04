using AutoMapper;
using MAVN.Service.Tiers.Domain.Entities;
using MAVN.Service.Tiers.MsSqlRepositories.Entities;

namespace MAVN.Service.Tiers.MsSqlRepositories
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
