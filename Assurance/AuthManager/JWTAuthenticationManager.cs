using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Assurance.AuthManager
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"user1","password1" },{"user2","password2"}
        };
        private readonly string key;
        public JWTAuthenticationManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(string username, string password)
        {
            if (!users.Any(x=>x.Key==username && x.Value == password))
            {
                return null;
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(key);
            var securityKey = new SymmetricSecurityKey(tokenkey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);//.RsaSha256Signature //.HmacSha256Signature
            var claims = new[] {
                                new Claim(ClaimTypes.Name, username),
                    };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = credentials
            };
            // var token = new JwtSecurityToken(null, null, claims,notBefore:null, expires: DateTime.Now.AddHours(3), signingCredentials: credentials);
            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }
    }
}
