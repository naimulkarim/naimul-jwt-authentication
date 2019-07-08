using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWTAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private ITokenService _tokenService;
        private IUserService _userService;

        public LoginController(IConfiguration config, ITokenService tokenService, IUserService userService)
        {
            _config = config;
            _tokenService = tokenService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]User login)
        {
            IActionResult response = Unauthorized();
            var user = _userService.Authenticate(login);

            if (user != null)
            {
                //var tokenString = GenerateJSONWebToken(user);
                var tokenString = _tokenService.GenerateJsonWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        //private string GenerateJSONWebToken(User userInfo)
        //{


        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[] {
        //        new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
        //        new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
        //        new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //        _config["Jwt:Issuer"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(120),
        //        signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private User AuthenticateUser(User login)
        //{
        //    User user = null;

        //    //Validate the User Credentials  
        //    //Demo Purpose, I have Passed HardCoded User Information  
        //    if (login.Username == "Jignesh")
        //    {
        //        user = new User { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com", Designation = "manager" };
        //    }
        //    return user;
        //}
    }
}