using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Represents user entity in DB
    /// </summary>
    public class User : IdentityUser
    {
        public int Score { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int Winrate { get; set; }

    }
}
