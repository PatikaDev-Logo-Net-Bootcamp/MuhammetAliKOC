using First.API.Models;
using First.App.Business.Abstract;
using First.App.Business.DTOs;
using Homework04_First.App.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace First.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtService jwtService;
        private readonly IUserService userService;


        public UserController(IJwtService jwtService, IUserService userService)
        {
            this.jwtService=jwtService;
            this.userService = userService;
        }

        /*Tüm kullanıcıları listeler.*/
        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            var users = userService.GetAllUser();
            return Ok(users);
        }


        /*Token buradan alınır.*/
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserModel model)
        {
            var token = jwtService.Authenticate(
                new UserDto 
                { 
                    Email = model.Email, Password = model.Password }
                );

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
