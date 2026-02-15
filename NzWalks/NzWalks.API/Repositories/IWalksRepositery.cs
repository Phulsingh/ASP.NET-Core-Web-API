using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public interface IWalksRepositery
    {
        Task<Walk> CreateAsync(Walk walk);

    }
}
