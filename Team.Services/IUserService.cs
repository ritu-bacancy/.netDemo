using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Data.Model;

namespace Team.Services
{
    public interface IUserService
    {
        public int AddUser(User user);

        public List<User> GetAllPlayer();

        public int setAsCaptain(int playerId);

        public int selectTeam(int[] players);

    }
}
