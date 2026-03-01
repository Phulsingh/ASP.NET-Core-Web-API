using NzWalks.API.Models.Domain;
using System.Net;

namespace NzWalks.API.Repositories
{
    public interface IImageRepositery
    {
        Task<Images> Upload(Images image);
    }
}
