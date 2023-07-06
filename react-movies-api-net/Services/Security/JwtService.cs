using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace react_movies_api_net.Services.Security
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(string subject)
        {
            var secretKey = _config.GetValue<string>("Jwt:SecretKey");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, subject)
            };

            var issuer = _config.GetValue<string>("Jwt:Issuer");
            var audience = _config.GetValue<string>("Jwt:Audience");
            int expiresIn = _config.GetValue<int>("Jwt:ExpiresIn");

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddSeconds(expiresIn), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetSubject(JwtSecurityToken token)
        {
            var subjectClaim = token.Claims.First(claims => claims.Type == ClaimTypes.NameIdentifier);
            return subjectClaim.Value;
        }

        public bool ValidateToken(string token)
        {
            var decodedToken = Decode(token);
            bool hasExpired = decodedToken.ValidTo > DateTime.UtcNow;

            return !hasExpired;
        }

        public JwtSecurityToken Decode(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadJwtToken(token);
        }
    }
}
