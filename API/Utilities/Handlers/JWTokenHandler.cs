using API.Contracts;
using API.DTOs.AccountData;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Utilities.Handlers;

public class JWTokenHandler : IJWTokenHandler
{
    private readonly IConfiguration configuration;

    public JWTokenHandler(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public ClaimData ExtractClaimFromJwt(string token)
    {
        if (token is null)
        {
            return new ClaimData();
        }

        try
        {
            // Token validation configuration
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = configuration["JWTService:Audience"],
                ValidateIssuer = true,
                ValidIssuer = configuration["JWTService:Issuer"],
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTService:SecretKey"]))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken != null && claimsPrincipal.Identity is ClaimsIdentity identity)
            {
                var claims = new ClaimData
                {
                    NameIdentifier = identity.FindFirst(ClaimTypes.NameIdentifier)!.Value,
                    Name = identity.FindFirst(ClaimTypes.Name)!.Value,
                    Email = identity.FindFirst(ClaimTypes.Email)!.Value
                };

                var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList();
                claims.Role = roles;

                return claims;
            }
        }
        catch
        {
            return new ClaimData();
        }

        return new ClaimData();
    }

    public string Generate(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTService:SecretKey"]));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        
        var tokenOpts = new JwtSecurityToken(
            issuer: configuration["JWTService:Issuer"],
            audience: configuration["JWTService:Audience"],
            expires: DateTime.Now.AddMinutes(6),
            signingCredentials: signingCredentials,
            claims: claims
            );
        var encodedToken = new JwtSecurityTokenHandler().WriteToken(tokenOpts);
        
        return encodedToken;
    }
}
