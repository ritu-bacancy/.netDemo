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
