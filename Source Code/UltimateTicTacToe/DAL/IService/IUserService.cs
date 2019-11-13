using System.Threading.Tasks;

namespace DAL.Service
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserDTO userDTO);

        Task<bool> IsUserExistAsync(UserDTO userDTO);
    }
}
