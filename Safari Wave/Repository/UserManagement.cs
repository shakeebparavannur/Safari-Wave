using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Users;
using Safari_Wave.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Safari_Wave.Repository
{
    public class UserManagement : IUserManagement
       
        
    {
        private readonly SafariWaveContext _context;
        private readonly IMapper _mapper;
        private string secretkey;
        private const string TwilioAccountSid = "AC048701c16a7786f1a73bc91570dcf0a6";
        private const string TwilioAuthToken = "d8efd7de8290347658447d339c38423b";
        private const string TwilioPhoneNumber = "9605896100";

        public UserManagement(SafariWaveContext context,IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            secretkey = configuration.GetValue<string>("Jwt:Key");
            _mapper = mapper;
        }
        public bool IsUniqueUser(string username)
        {
            var user = _context.UserData.FirstOrDefault(x=>x.UserName == username);
            if(user == null)
            {
                return true;
            }
            return false;
        }
        public bool IsUniqueEmail(string email) 
        { 
            var user = _context.UserData.FirstOrDefault(x=>x.Email ==  email);
            if(user == null)
            {
                return true;
            }
            return false;
        }
        public bool IsUniquePhonenumber(decimal phoneNumber)
        {
            var user = _context.UserData.FirstOrDefault(x=>x.PhoneNo == phoneNumber);
            if(user == null)
            {
                return true;
            }
            return false;
        }
        private string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }



        public async Task<LoginResponseDTO> Login(Login login)
        {
            var user =await _context.UserData.FirstOrDefaultAsync(u=>u.UserName.ToLower()==login.Username.ToLower());
            
            
            if(user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                return null;
            }
            if (user.IsActive==false)
            {
                return null;
            }
            var userDto = _mapper.Map<UserDTO>(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretkey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);  
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = userDto
            };
            return loginResponseDTO;
        }
        
        public async Task<UserDatum> Register(CreateUserDTO userDTO)
        {
            UserDatum userDatum = new UserDatum()
            {
                UserName = userDTO.UserName,
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                PhoneNo = userDTO.PhoneNo,
                Address = userDTO.Address,
                Pincode = userDTO.Pincode,
                State = userDTO.State,
                

            };
            userDatum.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password,10);
            userDatum.Role = "user";
            
            
            
            _context.UserData.Add(userDatum);
            await _context.SaveChangesAsync();

           

            userDatum.Password = "";
            return userDatum;
            

        }
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _context.UserData.Where(x=>x.Role=="user").ToListAsync();
            var usersDto =  _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDto;
        }

        public async Task<UserDTO> BlockUser(string username, bool isActive)
        {
            var user =await _context.UserData.Where(x=>x.UserName ==username).Where(p=>p.Role!="admin").FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            user.IsActive = isActive;
            await _context.SaveChangesAsync();
            var userDto =  _mapper.Map<UserDTO>(user);
            return userDto;
        }
        public async Task<UserDTO> EditUser(string username, UpdateUserDTO updateUser)
        {
            var user = _context.UserData.FirstOrDefault(x=>x.UserName ==username);

            if (user == null)
            {
                return null;
            }
            
            _mapper.Map(updateUser, user);
            await _context.SaveChangesAsync();
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public Task<bool> VerifyOtp(string username, string otp)
        {
            throw new NotImplementedException();
        }
    }
}
