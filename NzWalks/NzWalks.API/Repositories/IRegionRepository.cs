using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
    }
}
