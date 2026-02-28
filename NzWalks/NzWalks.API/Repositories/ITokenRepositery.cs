using Microsoft.AspNetCore.Identity;

namespace NzWalks.API.Repositories
{
    public interface ITokenRepositery
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
