using AutoMapper;

namespace NZWalks.API.Models.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Domain.Region, DTO.Region>()
                .ReverseMap();
            CreateMap<DTO.AddRegionRequest, Domain.Region>();
        }
    }
}
