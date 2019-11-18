using System.Threading.Tasks;

namespace DAL.Service
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserDTO userDTO);

        Task<User> GetExistingUser(UserDTO userDTO);

        Task<bool> UpdateUserAsync(User user);
    }
}
