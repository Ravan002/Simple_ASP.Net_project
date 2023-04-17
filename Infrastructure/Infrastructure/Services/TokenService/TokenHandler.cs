using Application.DTOs;
using Application.TokenService;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.TokenService
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreatAccessToken(int second)
        {
            Token token = new ();
            //Security Key-in  simmetrigini aliriq
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Token:SecurityKey")));

            // Sifrelenmis kimligin yaradilmasi
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //Yaranan tokenin ayarlarini veririk
            token.ExpirationTime = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken securityToken = new(
                audience : _configuration.GetValue<string>("Token:Audience"),
                issuer: _configuration.GetValue<string>("Token:Issuer"),
                expires: token.ExpirationTime,
                notBefore:DateTime.UtcNow,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
           token.AccessToken= tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
