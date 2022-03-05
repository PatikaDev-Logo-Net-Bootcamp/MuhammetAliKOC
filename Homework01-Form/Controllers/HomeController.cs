using Homework01_Form.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Homework01_Form.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new FormDTO());
        }

        [HttpPost]
        public IActionResult Index([FromBody] FormDTO login)
        {
            if (ModelState.IsValid)
            {
                //var res = JsonConvert.SerializeObject(new ResponseDTO() { Success = true, Data = "Giriş İşlemi Başarılı", Error = null });
                return Ok(new ResponseDTO() { Success = true, Data = "Giriş İşlemi Başarılı", Error = null });
            }
            return BadRequest(new ResponseDTO() { Success = false, Data = null, Error = "Hatalı Giriş!" });
        }


    }
}
