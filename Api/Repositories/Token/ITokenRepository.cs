using Microsoft.AspNetCore.Identity;

namespace Api.Repositories.Token
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
