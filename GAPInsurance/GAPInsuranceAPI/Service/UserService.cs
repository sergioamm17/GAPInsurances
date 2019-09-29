using Entities;
using GAPInsuranceAPI.Interface;
using GAPInsuranceAPI.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GAPInsuranceAPI.Service
{
    public class UserService : Interface.IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FullName = "Sergio Alonso Monge Monge", Username = "monge", Password = "123" }
        };

        private readonly SettingsConfig _settingsConfig;

        public UserService(IOptions<SettingsConfig> settingsConfig)
        {
            _settingsConfig = settingsConfig.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settingsConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }

    }
}
