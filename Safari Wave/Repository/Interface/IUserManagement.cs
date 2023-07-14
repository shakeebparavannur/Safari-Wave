using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Users;
using System.Security.Claims;

namespace Safari_Wave.Repository.Interface
{
    public interface IUserManagement
    {
       bool IsUniqueUser(string username);
       bool IsUniqueEmail(string email);
       bool IsUniquePhonenumber(decimal phonenumber);
       Task<LoginResponseDTO> Login(Login login);
       Task<LoginResponseDTO> AdminLogin(Login login);
       Task<UserDatum>Register(CreateUserDTO createUser);
       Task<IEnumerable<UserDTO>> GetAllUsers();
       Task <UserDTO> BlockUser (string  username,bool isActive);
       Task<UserDTO> EditUser(string username, UpdateUserDTO updateUser);
       Task<bool> VerifyOtp(string phoneNumber,string otp,UserDatum userdata);

        //Task<bool> VerifyEmail(string email);


    }
}
    