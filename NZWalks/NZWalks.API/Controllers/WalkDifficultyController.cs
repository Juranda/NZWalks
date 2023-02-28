using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalkDifficultyAsync()
        {
            var walkDiffs =  await walkDifficultyRepository.GetAllAsync();
            var walkDiffsDTO = mapper.Map<IEnumerable<Models.DTO.WalkDifficulty>>(walkDiffs);

            return Ok(walkDiffsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyAsync")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetWalkDifficultyAsync([FromRoute] Guid id)
        {
            var walkDiff = await walkDifficultyRepository.GetAsync(id);

            if (walkDiff is null) return NotFound();

            var walkDiffDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDiff);

            return Ok(walkDiffDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> PostWalkDifficultyAsync(Models.DTO.AddWalkDifficultyRequest walkDifficulty)
        {
            var walkDiff = mapper.Map<Models.Domain.WalkDifficulty>(walkDifficulty);

            walkDiff = await walkDifficultyRepository.PostAsync(walkDiff);

            var walkDiffDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDiff);

            return CreatedAtAction(nameof(GetWalkDifficultyAsync), new { id = walkDiffDTO.Id }, walkDiffDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> PutWalkDifficultyAsync([FromRoute] Guid id, [FromBody] Models.DTO.PutWalkDifficultyRequest addWalkDifficultyRequest)
        {
            var walkDiff = mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficultyRequest);

            walkDiff = await walkDifficultyRepository.PutAsync(id, walkDiff);

            if (walkDiff is null) return NotFound();

            var walkDiffDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDiff);

            return Ok(walkDiffDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync([FromRoute] Guid id)
        {
            var walkDiff = await walkDifficultyRepository.DeleteAsync(id);

            if (walkDiff is null) return NotFound();

            var walkDiffDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDiff);

            return Ok(walkDiffDTO);
        }
    }
}
