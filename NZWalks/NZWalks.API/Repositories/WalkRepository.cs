using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalkDbContext context;

        public WalkRepository(NZWalkDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await context.Walks.ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await context.Walks.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Walk> PostAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await context.Walks.AddAsync(walk);
            await context.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await context.Walks.FindAsync(id);

            if (walk is null) return null;

            context.Walks.Remove(walk);
            await context.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk> PutAsync(Guid id, Walk newWalk)
        {
            var walk = await context.Walks
                .Include(w => w.Region)
                .Include(w => w.WalkDifficulty)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (walk is null) return null;

            walk.Name = newWalk.Name;
            walk.Length = newWalk.Length;
            walk.RegionId = newWalk.RegionId;
            walk.WalkDifficultyId = newWalk.WalkDifficultyId;

            await context.SaveChangesAsync();

            return walk;
        }
    }
}
