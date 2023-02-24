using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
        //Get All
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        //Find id
        Task<WalkDifficulty> GetAsync(Guid id);
        //Post
        Task<WalkDifficulty> PostAsync(WalkDifficulty walkDifficulty);
        //Update/Put
        Task<WalkDifficulty> PutAsync(Guid id, WalkDifficulty walkDifficulty);
        //Delete
        Task<WalkDifficulty> DeleteAsync(Guid id);

    }
}
