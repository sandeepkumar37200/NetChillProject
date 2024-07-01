using Microsoft.IdentityModel.Tokens;
using Project.DAL;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.Services
{
   public  class TokenService: ITokenService
    {
        public string BuildToken(string Jwtkey, string issuer, User user)
        {
            // generation key for jwt
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(Jwtkey));

            // creating claims to describe JWT payload
            var claims = new Claim[]{
                new Claim(ClaimTypes.Name, user.EmailId),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
            };

            // creating JWT signature
            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature);

            // describing token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials,
                Issuer = issuer
            };

            // compiling JWt
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
    }
}
