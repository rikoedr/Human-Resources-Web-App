using API.DTOs.Auth;
using System.Security.Claims;

namespace API.Contracts;

public interface IJWTokenHandler
{
    string Generate(IEnumerable<Claim> claims);
    public ClaimData ExtractClaimFromJwt(string token);
}
