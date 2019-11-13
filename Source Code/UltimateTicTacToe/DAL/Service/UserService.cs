using DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserService : IUserService
    {
        private UserManager UserManager;

        public UserService(UserManager userManager)
        {
            UserManager = userManager;
        }

        public async Task<bool> CreateUserAsync(UserDTO userDTO)
        {
            if (userDTO.Password == userDTO.RepeatPassword &&
                await IsUserExistAsync(userDTO) == false)
            {
                var newUser = new User
                {
                    UserName = userDTO.Login,
                };
                var result = await UserManager.CreateAsync(newUser, userDTO.Password);
                return result.Errors.Count() > 0 ? false : true;
            }
            return false;
        }

        public async Task<bool> IsUserExistAsync(UserDTO userDTO)
        {
            var user = await UserManager.FindAsync(userDTO.Login, userDTO.Password);
            return user != null ? true : false;
        }

    }
}
