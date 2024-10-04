using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using ProductBase.Data;
using ProductBase.Server.RequestDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductBase.Server.Repositories
{
    public class LoginsRepo : ILoginRepo
    {
        private readonly ProdectDetailesDBContext _context;
        private readonly IConfiguration _configuration;

        public LoginsRepo(ProdectDetailesDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public string LoginDetails(LoginDTO loginDTO)
        {
            if (loginDTO.Username != null && loginDTO.Password != null)
            {
                var user = _context.Reg.SingleOrDefault(s => s.EmailId == loginDTO.Username && s.Password == loginDTO.Password);
                if (user != null)
                {
                    var claim = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["JWT:subject"]),
                        new Claim("Username", user.UserName),
                        new Claim("EmailId", user.EmailId),
                  };
                    var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(_configuration["JWT:SecretKey"]));
                    var SignIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var Token = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"], claim,
                        expires: DateTime.UtcNow.AddMinutes(10), signingCredentials: SignIn);
                    var JWTToken = new JwtSecurityTokenHandler().WriteToken(Token);
                    return JWTToken;
                }
                else
                {
                    throw new Exception("User is not Valid...!");
                }
            }
            else
            {
                throw new Exception("User Credential mismatch...! ");
            }
        }
        
    }
}
