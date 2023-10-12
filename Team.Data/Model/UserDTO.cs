using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Data.Model
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string accessToken { get; set; } = null!;


    }
}
