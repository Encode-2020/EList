using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EList.Data;
using EList.Dto;
using EList.Models;
using EList.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EList.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserRepository _repository;
        LoginResponse loginResponse;
        public LoginController(IUserRepository repository, IConfiguration config)
        {   
            _config = config;
            _repository = repository;
            loginResponse = new LoginResponse();

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                loginResponse.user = user;
                loginResponse.token = tokenString;
                response = Ok(new { loginResponse });
            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User login)
        {
            var user = _repository.GetUserByEmail(login.Email);

            if (user != null && login.Email == user.Email)
            {
                return user;
            }

            return null;

        }
    }
}

