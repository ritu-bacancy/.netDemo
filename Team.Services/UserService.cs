using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Data.Model;

namespace Team.Services
{
    public class UserService : IUserService
    {
        public readonly TeamContext _teamContext;

        public UserService(TeamContext teamContext)
        {
            _teamContext = teamContext;

        }

        public int AddUser(User userInfo)
        {
            try
            {
                var resCout = _teamContext.Users.Select(x => x.Id).ToList();
                if (resCout.Count > 15)
                {
                    return 3;
                }
                var checkEmail = _teamContext.Users.Where(x => x.Email == userInfo.Email).FirstOrDefault();
                if (checkEmail != null)
                {
                    return 4;
                }
                var user = new User();
                user.FirstName = userInfo.FirstName;
                user.LastName = userInfo.LastName;
                user.Email = userInfo.Email;
                user.RoleId = userInfo.RoleId;
                user.Height = userInfo.Height;
                user.Weight = userInfo.Weight;
                user.TotalMatchesPlayed = userInfo.TotalMatchesPlayed;
                user.ContactNumber = userInfo.ContactNumber;
                user.Password = "team1234";

                _teamContext.Users.Add(user);
                int res = _teamContext.SaveChanges();
                if (res == 1) {
                    return 1; 
                }
                else {
                    return 2; 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetAllPlayer()
        {
            try
            {
                var user = new List<User>();
                user = _teamContext.Users.ToList();
                return user;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
