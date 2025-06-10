using System.Security.Claims;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Jwt
{
    public interface IJwtManagerInterface
    {
        UsrToken GenerateToken(string userName);
        string GenerateRefreshToken();
        ClaimsPrincipal GetClaimsPrincipal(string token);
    }
}
