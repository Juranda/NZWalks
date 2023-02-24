using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if(region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostRegionAsync(Models.DTO.AddRegionRequest region)
        {
            var regionDomain = new Models.Domain.Region
            {
                Code = region.Code,
                Name = region.Name,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };
            regionDomain = await regionRepository.PostAsync(regionDomain);
            var regionDTO = new Models.DTO.Region
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                Area = regionDomain.Area,
                Lat = regionDomain.Lat,
                Long = regionDomain.Long,
                Population = regionDomain.Population
            };
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);

            if(region is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Models.DTO.Region>(region));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> PutRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.PutRegionRequest regionRequest)
        {
            //var region = new Models.Domain.Region
            //{
            //    Id = id,
            //    Code = regionRequest.Code,
            //    Name = regionRequest.Name,
            //    Area = regionRequest.Area,
            //    Lat = regionRequest.Lat,
            //    Long = regionRequest.Long,
            //    Population = regionRequest.Population
            //};

            var region = mapper.Map<Models.Domain.Region>(regionRequest);

            region = await regionRepository.PutAsync(id, region);

            if(region is null)
            {
                return NotFound();
            }

            //var regionDTO = new Models.DTO.Region
            //{
            //    Id = region.Id,
            //    Code = region.Code,
            //    Name = region.Name,
            //    Area = region.Area,
            //    Lat = region.Lat,
            //    Long = region.Long,
            //    Population = region.Population
            //};

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }
    }
}   
