using AutoMapper;
using Lykke.Service.Tiers.Client.Models.Reports;
using Lykke.Service.Tiers.Client.Models.Tiers;
using Lykke.Service.Tiers.Domain.Entities;

namespace Lykke.Service.Tiers
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
