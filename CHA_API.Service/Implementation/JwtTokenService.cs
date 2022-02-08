using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using CHA_API.Model;

namespace CHA_API.Service
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly AppSettings _appSettings;

        public JwtTokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<string> GenerateToken(string userName)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtTokenSettings.SecretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            List<int> roles = new List<int>() { 1, 2, 3, 4, 5 };
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("UserId", "1"));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim("Email", "abdul.shaikh@gebbs.com"));
            claims.Add(new Claim("UserDisplayName", "Abdul Aziz Shaikh"));
            claims.Add(new Claim("ClientId", "1"));
            claims.Add(new Claim("ClientName", "PHPNI"));
            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            });

            JwtSecurityToken securityToken = new JwtSecurityToken(_appSettings.JwtTokenSettings.Issuer,
                                                                  _appSettings.JwtTokenSettings.Audience,
                                                                  claims,
                                                                  expires: DateTime.Now.AddMinutes(_appSettings.JwtTokenSettings.ExpirationInMinutes),
                                                                  signingCredentials: credentials);
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return await Task.FromResult(jwtToken);
        }
    }
}
