using DAL.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {
        }
        public static UserManager Create(IdentityFactoryOptions<UserManager> options,
                                            IOwinContext context)
        {
            UserDbContext db = context.Get<UserDbContext>();
            UserManager manager = new UserManager(new UserStore<User>(db));
            return manager;
        }
    }
}
