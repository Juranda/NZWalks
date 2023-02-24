using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalkDbContext context;

        public WalkDifficultyRepository(NZWalkDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await context.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await context.WalkDifficulty.FirstOrDefaultAsync(wd => wd.Id == id);
        }

        public async Task<WalkDifficulty> PostAsync(WalkDifficulty walkDiff)
        {
            walkDiff.Id = Guid.NewGuid();
            await context.WalkDifficulty.AddAsync(walkDiff);
            await context.SaveChangesAsync();
            return walkDiff;
        }

        public async Task<WalkDifficulty> PutAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var walkDiff = await context.WalkDifficulty.FindAsync(id);

            if (walkDiff is null) return null;

            walkDiff.Code = walkDifficulty.Code;
            await context.SaveChangesAsync();

            return walkDiff;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDiff = await context.WalkDifficulty.FindAsync(id);

            if (walkDiff is null) return null;

            context.WalkDifficulty.Remove(walkDiff);
            await context.SaveChangesAsync();

            return walkDiff;
        }
    }
}
