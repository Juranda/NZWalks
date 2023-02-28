using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetAsync(Guid id);
        Task<Walk> PostAsync(Walk walk);
        Task<Walk> PutAsync(Guid id, Walk walk);
        Task<Walk> DeleteAsync(Guid id);
    }
}
