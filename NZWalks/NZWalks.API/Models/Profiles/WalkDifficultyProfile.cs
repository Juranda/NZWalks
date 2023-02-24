using AutoMapper;

namespace NZWalks.API.Models.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
                .ReverseMap();

            CreateMap<Models.DTO.AddWalkDifficultyRequest, Models.Domain.WalkDifficulty>();
            CreateMap<Models.DTO.PutWalkDifficultyRequest, Models.Domain.Walk>();
        }
    }
}
