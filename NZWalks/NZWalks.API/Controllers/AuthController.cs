using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequest userLoginRequest)
        {
            var user = await userRepository
                .Authenticate(userLoginRequest.Username, userLoginRequest.Password);
           
            if (user is null) return BadRequest("Username or password is incorrect");

            var token = await tokenHandler.CreateTokenAsync(user);

            return Ok(token);
        }
    }
}
