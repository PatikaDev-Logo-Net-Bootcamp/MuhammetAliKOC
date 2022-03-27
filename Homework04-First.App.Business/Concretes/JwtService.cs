using First.App.Business.Abstract;
using First.App.Business.DTOs;
using Homework04_First.App.Business.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace First.App.Business.Concretes
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public JwtService(IConfiguration configuration, IUserService userService)
        {
            this._configuration=configuration;
            this._userService = userService;
        }

        /// <summary>
        /// Users Repositoryi yazıp bu dataları veritabanından da çekebilirsiniz.
        /// </summary>
        //Dictionary<string, string> users = new Dictionary<string, string>
        //{
        //    { "1","1"},
        //    { "2","2"},
        //    { "3","3"},
        //};
        public TokenDto Authenticate(UserDto user)
        {
            //if (!users.Any(x => x.Key == user.Name && x.Value == user.Password))
            //{
            //    return null;
            //}

            /*kullanici mail ve şifre uyuşmuyorsa token oluşturma!*/
            if (!_userService.CheckUser(user.Email, user.Password))
            {
                return null;
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, user.Email)
              }),
                Expires = DateTime.UtcNow.AddMinutes(100),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto 
            { 
                Token = tokenHandler.WriteToken(token) 
            };
        }
    }
}
