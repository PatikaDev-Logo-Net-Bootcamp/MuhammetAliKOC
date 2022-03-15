using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02_Middlewares_Swaggers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Login()
        {
            return Ok("Login Success");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return Ok("Register Success");
        }

        //Swaggerda saklanan action.
        [HttpGet]
        public ActionResult Hide()
        {
            return Ok("Hide Success");
        }
        [HttpGet]
        public ActionResult Test()
        {
            return Ok("Test Success");
        }
    }
}
