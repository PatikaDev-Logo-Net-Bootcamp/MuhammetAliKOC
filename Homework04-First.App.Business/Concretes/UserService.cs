using First.App.Business.DTOs;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using Homework04_First.App.Business.Abstract;
using Homework04_First.App.Business.Helpers;
using HomeWork04_First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework04_First.App.Business.Concretes
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<User> Users()
        {
            return repository.Get();
        }
        public User GetUser(int id)
        {
            return Users().FirstOrDefault(x => x.Id == id);
        }

        public User GetUser(string  email)
        {
            return Users().FirstOrDefault(x => x.Email == email);
        }
        public List<UserDto> GetAllUser()
        {
            return repository.Get().Select(x => new UserDto() {Email = x.Email, Name = x.Name, Surname = x.Surname }).ToList();
        }
        public void AddUser(User user)
        {
            repository.Add(user);
            unitOfWork.Commit();
        }

        public bool CheckUser(string email, string password)
        {
            var user = GetUser(email);
            /*Emaili kullanın kullanici var mi ?*/
            if (user==null)
            {
                return false;
            }
            /*şifre doğru girldi mi?*/
            if (user.Password == CryptographyHelper.MD5_Encode(password))
            {
                return true;
            }

            return false;
        }
    }
}
