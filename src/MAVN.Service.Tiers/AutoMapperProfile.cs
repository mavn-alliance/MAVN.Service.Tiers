using AutoMapper;
using MAVN.Service.Tiers.Client.Models.Reports;
using MAVN.Service.Tiers.Client.Models.Tiers;
using MAVN.Service.Tiers.Domain.Entities;

namespace MAVN.Service.Tiers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TierCustomersCount, TierCustomersCountModel>(MemberList.Source);

            CreateMap<Tier, TierModel>(MemberList.Source);
            CreateMap<TierModel, Tier>(MemberList.Destination);
        }
    }
}
