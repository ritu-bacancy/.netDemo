using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Team.Data.Model;

namespace Team.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        public readonly TeamContext _teamContext;
        private readonly IConfiguration _configuration;


        public AuthenticationService(TeamContext teamContext, IConfiguration configuration)
        {
            _teamContext = teamContext;
            _configuration = configuration;

        }
        public UserDTO Login(LoginVM login)
        {
            try
            {
                User user = new User();

                user = _teamContext.Users.Where(x => x.Email == login.Email && x.Password == login.Password).First();

                UserDTO userDTO = new UserDTO();

                if(user != null)
                {
                    userDTO.Email = user.Email;
                    userDTO.Id = user.Id;

                    // authentication successful so generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AccessToken").Value);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Email)
                        }),

                        Expires = DateTime.UtcNow.AddMinutes(60),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    userDTO.accessToken = tokenHandler.WriteToken(token);

                    return userDTO;
                }
                else
                {
                    throw new HttpRequestException("Invalid Username or password");

                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public int changePassword(string email, string password)
        {
            var player = _teamContext.Users.FirstOrDefault(x => x.Email == email);
            player.Password = password;
            _teamContext.Users.Update(player);
            var res = _teamContext.SaveChanges();
            if(res == 1)
            {
                return 1;
            }else
            {
                return 0;
            }
        }
    }
}
