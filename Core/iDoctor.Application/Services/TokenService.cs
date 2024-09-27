using iDoctor.Application.Dtos.Token;
using iDoctor.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace iDoctor.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDto GenerateJwtToken(TokenCreateDto request)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, request.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //request.Roles.ForEach(role =>
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //});

            var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);


            TokenDto tokenDto = new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return tokenDto;
        }
    }
}
