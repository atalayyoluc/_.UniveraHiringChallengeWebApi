using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace _.UniveraHiringChallengeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        
        public async Task<IActionResult> Login([FromBody]UserLoginDTO userLoginDTO)
        {
            

                var userToken = await userService.Login(userLoginDTO);
                if (userToken!=null)
                {
                
                    return Ok(userToken);
                }
                else
                {
                    return BadRequest();
                }
            
        }
            [HttpPost("Register")]
            public async Task<IActionResult> Register(UserDTO userDTO)
            {
                var user=await userService.Register(userDTO);

                return Ok(user);
            }
        
    } }
