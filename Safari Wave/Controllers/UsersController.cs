using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Users;
using Safari_Wave.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Safari_Wave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        protected APIResponse response;
        public UsersController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
            response = new();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var LoginResponse = await _userManagement.Login(login);
                if (LoginResponse == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Username or Password is Incorrect");
                    return BadRequest(response);
                }

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                };
                Response.Cookies.Append("jwt", LoginResponse.Token, cookieOptions);

                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = LoginResponse;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO createUser)
        {
            bool ifUserNameUnique = _userManagement.IsUniqueUser(createUser.UserName);
            if (!ifUserNameUnique)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Username already exists");
                return BadRequest(response);
            }
            bool ifEmailUnique = _userManagement.IsUniqueEmail(createUser.Email);
            if (!ifEmailUnique)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Email already regsitered");
                return BadRequest(response);
            }
            bool ifNumberUnique = _userManagement.IsUniquePhonenumber(createUser.PhoneNo);
            if (!ifNumberUnique)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Phone number already exist");
                return BadRequest(response);
            }
            var user = await _userManagement.Register(createUser);
            if (user == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Error while registering");
                return BadRequest(response);
            }
            response.StatusCode = HttpStatusCode.OK;
            response.IsSuccess = true;
            return Ok(response);


        }
        [Authorize(Roles = "admin")]
        [HttpGet("users")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userManagement.GetAllUsers();
            if (users == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;  
                response.IsSuccess = true;
                response.ErrorMessages.Add("No users found");
                return NotFound(response);
            }
            response.StatusCode=HttpStatusCode.OK;
            response.IsSuccess = true;
            response.Result = users;
            return Ok(response);

        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("api/Users/{username}/Isactive")]
        public ActionResult BlockUser(string username, [FromBody] bool isActive)
        {
            var blockedUser = _userManagement.BlockUser(username, isActive);
            if (blockedUser == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Some thing went wrong");
                return BadRequest(response);
            }
            return Ok($"{blockedUser.Result.UserName} has been blocked");
        }
        [Authorize]
        [HttpPut("/update/")]
        public async Task<ActionResult> UpdateData(UpdateUserDTO updateUser)
        {
            var currentUser = HttpContext.User.Identity.Name;
            bool ifEmailUnique = _userManagement.IsUniqueEmail(updateUser.Email);
            bool ifNumberUnique = _userManagement.IsUniquePhonenumber(updateUser.PhoneNo);
            if (!ifEmailUnique)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Email is already registered");
                return BadRequest(response);

            }
            else if (!ifNumberUnique)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Mobile Number is already registered");
                return BadRequest(response);
            }
            var updatedUser = await _userManagement.EditUser(currentUser, updateUser);

            if (updatedUser == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Cannot make changes");
                return BadRequest(response);
            }
            response.StatusCode = HttpStatusCode.OK;
            response.IsSuccess = true;
            response.Result = updatedUser;
            return Ok(response);
        }
    }
}
