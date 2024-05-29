using AutoMapper;
using HumanManagement.DataAccess.DTOs;
using HumanManagement.DataAccess.Models;
using HumanManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HumanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateServices _authenticationService;
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;

        public AuthenticateController(
             IAuthenticateServices authenticationService,
             IUserServices userService,
             IMapper mapper)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDTO login)
        {

            var user = await _userService.getUserByUserName(login.Username);
            if (user != null)
            {
                if (login.Username != user.Username)
                {
                    return BadRequest("User not found.");
                }
                if (BCrypt.Net.BCrypt.Verify(login.Password, user.Password) == false)
                {
                    return BadRequest("Wrong password");
                }


                string token = _authenticationService.createToken(user);
                var refreshToken = _authenticationService.generateRefreshToken();
                _authenticationService.setRefreshToken(user, refreshToken);

                return Ok(token);
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO request)
        {
            var existingUser = await _userService.getUserByUserName(request.Username);
            if (existingUser != null)
            {
                return BadRequest(new { Message = "Username already exists." });
            }

            var newUser = _mapper.Map<RegisterDTO, User>(request);

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            newUser.DaysOffCount = 0;

            _userService.createUser(newUser);


            var userResponse = _mapper.Map<User, UserDTO>(newUser);

            return Ok(userResponse);

        }
    }
}
