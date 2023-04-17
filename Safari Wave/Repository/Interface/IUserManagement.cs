using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Users;
using System.Security.Claims;

namespace Safari_Wave.Repository.Interface
{
    public interface IUserManagement
    {
       bool IsUniqueUser(string username);
       bool IsUniqueEmail(string email);
       bool IsUniquePhonenumber(int phonenumber);
       Task<LoginResponseDTO> Login(Login login);
       Task<UserDatum>Register(CreateUserDTO createUser);
       Task<IEnumerable<UserDTO>> GetAllUsers();
       Task <UserDTO> BlockUser (string  username,bool isActive);
       Task<UserDTO> EditUser(string username, UpdateUserDTO updateUser);

    }
}
    