using BazaFilmowa.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BazaFilmowa.Services
{
    public class JwtTokenProviderService : IJwtTokenProviderService
    {
        AuthenticationSettings _authenticationSettings;
        public JwtTokenProviderService(AuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
        }

        public string GetJwtForUser(User user)
        {
            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}"),
                        new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                            _authenticationSettings.JwtIssuer,
                            _authenticationSettings.JwtIssuer,
                            claims,
                            expires: expires,
                            signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
