using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext context;

        public RegionRepository(NZWalkDbContext context)
        {
            this.context = context;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await context.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (region == null)
            {
                return null;
            }

            context.Regions.Remove(region);
            await context.SaveChangesAsync();

            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await context.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> PostAsync(Region region)
        {
            region.Id = Guid.NewGuid();

            await context.Regions.AddAsync(region);
            await context.SaveChangesAsync();
            return region;  
        }

        public async Task<Region> PutAsync(Guid id, Region region)
        {
            var regionDomain = await context.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if(regionDomain == null)
            {
                return null;
            }

            regionDomain.Code = region.Code;
            regionDomain.Name = region.Name;
            regionDomain.Area = region.Area;
            regionDomain.Lat = region.Lat;
            regionDomain.Long = region.Long;
            regionDomain.Population = region.Population;
            regionDomain.Walks = region.Walks;

            await context.SaveChangesAsync();

            return regionDomain;
        }
    }
}
