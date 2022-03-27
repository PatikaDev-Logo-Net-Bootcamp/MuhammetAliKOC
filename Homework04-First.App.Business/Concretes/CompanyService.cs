using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using Homework04_First.App.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace First.App.Business.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
          this.repository = repository;
          this.unitOfWork = unitOfWork;
        }
        public IQueryable<Company> Companies()
        {
            return repository.Get();
        }
        public Company GetCompany(int id)
        {
            return Companies().FirstOrDefault(x=>x.Id ==id);
        }
        public List<Company> GetAllCompany()
        {
            return repository.Get().ToList();
        }
        public void AddCompany(Company company)
        {
            repository.Add(company);
            unitOfWork.Commit();
        }







        #region Ödev İçin Hazırlanan Update Ve Delete
        public CompanyResponseDTO UpdateCompany(int id, Company company, string updatedBy = "Api Kullanicisi")
        {
            if (id != company.Id)
            {
                return new CompanyResponseDTO()
                {
                    Error = "Bad Request"
                };
            }

            var companyEntity = GetCompany(id);
            if (companyEntity == null)
            {
                return new CompanyResponseDTO()
                {
                    Error = "Bad Request"
                };
            }

            companyEntity.Address = company.Address;
            companyEntity.City = company.City;
            companyEntity.Country = company.Country;
            companyEntity.Description = company.Description;
            companyEntity.LastUpdatedAt = DateTime.Now;
            companyEntity.LastUpdatedBy = updatedBy;
            companyEntity.Location = company.Location;
            companyEntity.Name = company.Name;
            companyEntity.Phone = company.Phone;

            try
            {
                repository.Update(companyEntity);
                unitOfWork.Commit();
            }
            catch (Exception)
            {

                return new CompanyResponseDTO()
                {
                    Error = "Internal Server Error"
                };
            }

            return new CompanyResponseDTO()
            {
                Success = true
            };
        }

        public CompanyResponseDTO DeleteSoftCompany(int id, Company company, string updatedBy = "Api Kullanicisi")
        {
            if (id != company.Id)
            {
                return new CompanyResponseDTO()
                {
                    Error = "Bad Request"
                };
            }

            var companyEntity = GetCompany(id);
            if (companyEntity == null)
            {
                return new CompanyResponseDTO()
                {
                    Error = "Bad Request"
                };
            }
            companyEntity.LastUpdatedAt = DateTime.Now;
            companyEntity.LastUpdatedBy = updatedBy;
            companyEntity.IsDeleted = true;
            try
            {
                repository.Update(companyEntity);
                unitOfWork.Commit();
            }
            catch (Exception)
            {

                return new CompanyResponseDTO()
                {
                    Error = "Internal Server Error"
                };
            }


            return new CompanyResponseDTO()
            {
                Success = true
            };

        }

        public CompanyResponseDTO DeleteHardCompany(int id, Company company, string updatedBy = "Api Kullanicisi")
        {
            if (id != company.Id)
            {
                return new CompanyResponseDTO()
                {
                    Error = "Bad Request"
                };
            }

            var companyEntity = repository.GetAll().Where(x=>x.Id ==id).FirstOrDefault();
            if (companyEntity == null)
            {
                return new CompanyResponseDTO()
                {
                    Error = "Bad Request"
                };
            } 
 
            try
            {
                repository.Delete(companyEntity);
                unitOfWork.Commit();
            }
            catch (Exception)
            {

                return new CompanyResponseDTO()
                {
                    Error = "Internal Server Error"
                };
            }


            return new CompanyResponseDTO()
            {
                Success = true
            };

        }

        #endregion


    }
}
