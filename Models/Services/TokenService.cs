using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductManagementWebApi.Models.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementWebApi.Models.Services
{
    public class TokenService : ITokenService
    {
        readonly IConfiguration configuration;
        public TokenService(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }


        public Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest request)
        {

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));
           
            var dateTime = DateTime.Now;

            JwtSecurityToken jwt = new JwtSecurityToken(
                
                issuer: configuration["AppSetttings:ValidIssuer"],
                audience: configuration["AppSettings:Valid"],
                claims: new List<Claim>
                {
                    new Claim("userName", request.Username)
                },
                notBefore: dateTime,
                expires: dateTime.Add(TimeSpan.FromMinutes(3)),
                signingCredentials:new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)

            );

            return Task.FromResult(new GenerateTokenResponse{
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate = dateTime.Add(TimeSpan.FromMinutes(3)),
            });
            throw new NotImplementedException();
        }
    }
}
