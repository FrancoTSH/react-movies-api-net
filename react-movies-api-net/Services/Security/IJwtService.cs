using System.IdentityModel.Tokens.Jwt;

namespace react_movies_api_net.Services.Security
{
    public interface IJwtService
    {
        public string GenerateToken(string subject);

        public bool ValidateToken(string token);

        public string GetSubject(JwtSecurityToken token);

        public JwtSecurityToken Decode(string token);
    }
}
