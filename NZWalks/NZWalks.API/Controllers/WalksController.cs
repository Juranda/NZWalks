using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomain = await walkRepository.GetAllAsync();
            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walksDomain);
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walk = await walkRepository.GetWalkAsync(id);

            if(walk == null) return NotFound();

            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);

            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddWalkRequest walkRequest)
        {
            //var walk = new Models.Domain.Walk
            //{
            //    Name = walkRequest.Name,
            //    Length = walkRequest.Length,
            //    RegionId = walkRequest.RegionId,
            //    WalkDifficultyId = walkRequest.WalkDifficultyId
            //};

            var walk = mapper.Map<Models.Domain.Walk>(walkRequest);

            walk = await walkRepository.PostWalkAsync(walk);

            //var walkDTO = new Models.DTO.Walk
            //{
            //    Name = walk.Name,
            //    Length = walk.Length,
            //    RegionId = walkRequest.RegionId,
            //    WalkDifficultyId = walkRequest.WalkDifficultyId
            //};

            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);

            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var walk = await walkRepository.DeleteWalkAsync(id);

            if (walk is null) return NotFound();

            var walkDTO = new Models.DTO.Walk
            {
                Id = walk.Id,
                Name = walk.Name,
                Length = walk.Length,
                RegionId = walk.RegionId,
                WalkDifficultyId = walk.WalkDifficultyId
            };

            return Ok(walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> PutWalkAsync([FromRoute] Guid id, [FromBody] PutWalkRequest putWalkRequest)
        {
            var walk = mapper.Map<Models.Domain.Walk>(putWalkRequest);

            walk = await walkRepository.PutWalkAsync(id, walk);

            if (walk is null) return NotFound();

            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);

            return Ok(walkDTO);
        }
    }
}
