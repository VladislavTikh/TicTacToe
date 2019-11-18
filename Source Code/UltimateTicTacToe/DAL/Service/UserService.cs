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
        private UserManager _userManager;

        public UserService(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> CreateUserAsync(UserDTO userDTO)
        {
            if (userDTO.Password == userDTO.RepeatPassword &&
                await GetExistingUser(userDTO) == null)
            {
                var newUser = new User
                {
                    UserName = userDTO.Login,
                };
                var result = await _userManager.CreateAsync(newUser, userDTO.Password);
                return result.Errors.Count() < 1 ? await _userManager.FindAsync(userDTO.Login,userDTO.Password) : null;
            }
            return null;
        }

        public async Task<User> GetExistingUser(UserDTO userDTO)
        {
            var user = await _userManager.FindAsync(userDTO.Login, userDTO.Password);
            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var identity= await _userManager.UpdateAsync(user);
            return identity.Succeeded;
        }
    }
}
