using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext()
            : base("DefaultConnection")
        {
        }

        public static UserDbContext Create()
        {
            return new UserDbContext();
        }
    }
}
