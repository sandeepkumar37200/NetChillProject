using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project.API.Dtos;
using Project.API.Errors;
using Project.DAL;

using Project.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    public class AuthController : BaseController
    {

        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthController(IAccountService accountService, IConfiguration configuration, IMapper mapper, ITokenService tokenService) 
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _mapper = mapper;
            _configuration = configuration;

        }

        // api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginRequest) 
        {

            var user = await _accountService.AuthenticateUser(loginRequest.EmailId, loginRequest.Password);
            if (user == null)
            {
                return NotFound(new ApiError(404, "Invalid credential"));
            }

            LoginResDto loginResponse = new LoginResDto
            {
                EmailId = user.EmailId,
                Token = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(),_configuration["Jwt:Issuer"].ToString(), user),
                UserId = user.Id,
                IsAdmin = user.IsAdmin
            };
            return Ok(loginResponse);
        }




        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterReqDto registerRequest)
        {
            if (await _accountService.UserAlreadyExist(registerRequest.EmailId))
            {
                return BadRequest(new ApiError(400, $"{registerRequest.EmailId} is taken"));
            }
            if (registerRequest.UnHashedPassword != registerRequest.ConfirmPassword)
            {
                return BadRequest(new ApiError(400, "Password and Confirm Password don't match"));
            }

            byte[] Password, PasswordKey;

            using (var hmac = new HMACSHA512())
            {
                PasswordKey = hmac.Key;
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerRequest.UnHashedPassword));
            }

            Guid newUserId = Guid.NewGuid();

            User newUser = _mapper.Map<User>(registerRequest);
            newUser.PasswordHash = Password;
            newUser.PasswordSalt = PasswordKey;
            newUser.Id = newUserId;

          

            if (await _accountService.Register(newUser))
            {
                return Ok();
            }
            return BadRequest(new ApiError(400, "Some error occured Registration failed."));
        }



    }
}
