﻿using First.API.Filters;
using First.API.Models;
using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace First.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        //[HttpGet]
        //[ServiceFilter(typeof(ActionFilterExample))]
        //public IActionResult GetData()
        //{
        //    return Ok(new { data = "Veriler Yüklendi"});
        //}

        [HttpGet]
        [Log]
        public IActionResult Log()
        {
            return NoContent();
        } 

        /// <summary>
        /// Tüm şirket bilgilerini getirir.
        /// </summary>
        /// <returns></returns>
        [Route("Compaines")]
        [HttpGet]
        public IActionResult Get()
        {
            var companies = companyService.GetAllCompany().Select(x=> new CompanyDto
            {
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                Description = x.Description,
                Location = x.Location,
                Phone = x.Phone               
            });
            return Ok(new CompanyResponse { Data = companies, Success = true });
        }


        /// <summary>
        /// Şirket ekleme işlemi yapar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddCompany")]
        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto model)
        {
            companyService.AddCompany(new Company
            {
                Address = model.Address,
                City = model.City,
                Description = model.Description,
                CreatedBy = "SAMET",
                CreatedAt = System.DateTime.Now,
                IsDeleted = false,
                Name = model.Name.ToUpper(),
                Country = model.Country,
                Phone = model.Phone,
                Location = model.Location,
            });
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }








        /// <summary>
        /// Update işlemi.
        /// </summary>
        /// <returns></returns>
        [Route("Update/{id}")]
        [HttpPut]
        public IActionResult Update(int id, [FromBody]Company company)
        {
            string username = "";
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                username = identity.FindFirst(ClaimTypes.Name).Value;
            }

            var result = companyService.UpdateCompany(id,company,username);
            if (result.Success)
            {
                return NoContent();
            }else
            {
                return BadRequest(result.Error);
            }         
        }

        /// <summary>
        ///Pasife alan Silme işlemi.Soft delete.
        /// </summary>
        /// <returns></returns>

        [Route("Delete/{id}")]
        [HttpPatch]
        public IActionResult DeleteSoft(int id, [FromBody] Company company)
        {
            string username = "";
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                username = identity.FindFirst(ClaimTypes.Name).Value;
            }

            var result = companyService.DeleteSoftCompany(id, company, username);
            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        /// <summary>
        ///Tamamen ortadan kaldıran Silme işlemi. Hard delete.
        /// </summary>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteHard(int id, [FromBody] Company company)
        {
            string username = "";
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                username = identity.FindFirst(ClaimTypes.Name).Value;
            }

            var result = companyService.DeleteHardCompany(id, company, username);
            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

    }
}