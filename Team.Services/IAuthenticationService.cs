using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Data.Model;

namespace Team.Services
{
    public interface IAuthenticationService
    {
        public User Login(LoginVM login);

    }
}
