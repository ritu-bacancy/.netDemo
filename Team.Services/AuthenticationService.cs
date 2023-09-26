using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Data.Model;

namespace Team.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        public readonly TeamContext _teamContext;

        public AuthenticationService(TeamContext teamContext)
        {
            _teamContext = teamContext;
        }
        public User Login(LoginVM login)
        {
            try
            {
                User user = new User();

                user = _teamContext.Users.Where(x => x.Email == login.Email && x.Password == login.Password).First();

                return user;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
