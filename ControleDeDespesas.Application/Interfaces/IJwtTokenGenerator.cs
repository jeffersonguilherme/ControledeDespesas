using System.Security.Claims;

namespace ControleDeDespesas.Application.Interfaces;

public interface IJwtTokenGenerator
{
    (string toke, DateTime expiresAtutc) GenerateToken(IEnumerable<Claim> claims);
}