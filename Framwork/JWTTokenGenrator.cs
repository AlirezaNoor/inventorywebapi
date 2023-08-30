using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Framwork.Interface;
using INV.Domin;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Framwork
{
    public  class JWTTokenGenrator: IJWTTokenGenrator
    {
         private readonly UserManager<ApplicationUser> _userManager;
         private readonly SymmetricSecurityKey _key;

         public JWTTokenGenrator(IConfiguration config , UserManager<ApplicationUser> userManager)
         {
             _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokenkey"]));
             _userManager = userManager;
         }

         public async Task<string> CreateToken(ApplicationUser user)
         {
            var claims=new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(x=>new Claim(ClaimTypes.Role,x)));
            var Creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDiscriber = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateAndTime.Now.AddDays(1),
                SigningCredentials = Creds
            };
            var tokenhandeler = new JwtSecurityTokenHandler();
            var token = tokenhandeler.CreateToken(TokenDiscriber);
            return tokenhandeler.WriteToken(token);
         }
    }
}
