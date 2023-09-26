using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Data.Model
{
    public class TeamContext: DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options): base(options) 
        {
         //Database.EnsureCreated();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
