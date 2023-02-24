using AutoMapper;

namespace NZWalks.API.Models.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>()
                .ReverseMap();

            CreateMap<Models.DTO.AddWalkRequest, Models.Domain.Walk>();
            CreateMap<Models.DTO.PutWalkRequest, Models.Domain.Walk>();

            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
                .ReverseMap();
        }
    }
}
