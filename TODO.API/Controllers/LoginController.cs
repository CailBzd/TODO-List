using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;
using TODO.API.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using TODO.Domain.Models;
using TODO.Domain.Services;
using System.Threading.Tasks;

namespace TODO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login,
            [FromServices] AuthenticateUser handler)
        {
            Console.WriteLine("--> LoginController : Login");

            var auth = await handler.Login(login.Username, login.Password);

            if (auth != null)
            {
                var tokenString = GenerateJSONWebToken(auth);
                return Ok(new { access_token = tokenString });
            }

            return BadRequest(new { message = "Auth failed" }) ;
        }

        
        private string GenerateJSONWebToken(User userInfo)
        {
           Console.WriteLine("--> LoginController : GenerationJSONWebToken");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new ClaimsIdentity(new[] { new Claim("id", userInfo.Id.ToString()) });

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = credentials
            };

        var token = new JwtSecurityTokenHandler().CreateToken(tokenDesc);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
