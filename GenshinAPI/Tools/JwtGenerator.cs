using GenshinAPI.Models.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GenshinAPI.Tools
{
    public class JwtGenerator
    {
        private IConfiguration _config;

        public JwtGenerator(IConfiguration config)
        {
            _config = config;
        }
        public string Generate(ConnectedUserDTO user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("user");
            }

            string key = _config.GetSection("tokenInfo").GetSection("secretKey").Value;
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials signingKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] myClaims = new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Username", user.Username),
                new Claim("Avatar_Id",user.Avatar_Id.ToString())
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                    claims: myClaims,
                    signingCredentials: signingKey,
                    expires: DateTime.Now.AddDays(1),
                    issuer: "https://localhost:7038", //Emetteur du token
                    audience: "http://localhost:4200" //Consomateur du token
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}
