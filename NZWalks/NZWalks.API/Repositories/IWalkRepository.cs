using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetWalkAsync(Guid id);
        Task<Walk> PostWalkAsync(Walk walk);
        Task<Walk> PutWalkAsync(Guid id, Walk walk);
        Task<Walk> DeleteWalkAsync(Guid id);
    }
}
