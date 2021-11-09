using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OPLOGInventory.Application.ApiUsers;
using OPLOGInventory.Model;

namespace OPLOGInventory.API.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private IApiUserApplication _apiuserapplication;

        public LoginController(IConfiguration config, IApiUserApplication apiuserapplication)
        {
            _config = config;
            _apiuserapplication = apiuserapplication;
        }

        /// <summary>
        /// Login and get Token for API
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("token")]
        [HttpPost]
        public IActionResult Login([FromForm] LoginDto input)
        {
            if (input == null)
                return NotFound();

            var result = _apiuserapplication.GetApiUser(input);

            if (result.IsError)
            {
                return NotFound();
            }
            else
            {

                var tokenString = GenerateToken(result.Data.Username, result.Data.Role);

                return Ok(new { token = tokenString });
            }
        }

        private string GenerateToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "OPLOG",
                Issuer = "OPLOG.Issuer.Prod",
                Subject = new ClaimsIdentity(new Claim[]
                {
                        //Add any claim
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role,role)
                }),

                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}