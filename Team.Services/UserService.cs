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
            var userCount = _teamContext.Users.Select(x => x.Id).ToList();
            if (userCount.Count > 15)
            {
                return 2;
            }
            var isUserExist = _teamContext.Users.Where(x => x.Email.Contains(userInfo.Email)).FirstOrDefault();
            if(isUserExist != null)
            {
                return 3;
            }
            _teamContext.Users.Add(userInfo);
            int res = _teamContext.SaveChanges();
            if(res == 1)
            {
                return 1;
            }else
            {
                return 0;

            }

            /*try
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
            }*/
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

        public int setAsCaptain(int playerId)
        {
            var player = _teamContext.Users.Find(playerId);
            var ifCaptainExist = _teamContext.Users.Where(x => x.RoleId == 2).FirstOrDefault();
            if (ifCaptainExist != null)
            {
                var existingCaptain = _teamContext.Users.Find(ifCaptainExist.Id);
                existingCaptain.RoleId = 3;
                _teamContext.Users.Update(existingCaptain);
                _teamContext.SaveChanges();
            }

            player.RoleId = 2;
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

        public int selectTeam(int[] players)
        {
            var getPlayer = _teamContext.Users.Where(x => players.Contains(x.Id));
            foreach (var player in getPlayer)
            {
                player.IsActiveMember = 'Y';
            }

            var res = _teamContext.SaveChanges();
            return res;
        }
    }
}
