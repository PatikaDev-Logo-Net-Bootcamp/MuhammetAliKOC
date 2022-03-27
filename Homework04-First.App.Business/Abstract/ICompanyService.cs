using First.App.Business.DTOs;
using First.App.Domain.Entities;
using Homework04_First.App.Business.DTOs;
using System.Collections.Generic;

namespace First.App.Business.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetAllCompany();
        void AddCompany(Company company);

        CompanyResponseDTO UpdateCompany(int id, Company company, string updatedBy = "Api Kullanicisi");

        CompanyResponseDTO DeleteSoftCompany(int id, Company company, string updatedBy = "Api Kullanicisi");

        CompanyResponseDTO DeleteHardCompany(int id, Company company, string updatedBy = "Api Kullanicisi");
    }
}
