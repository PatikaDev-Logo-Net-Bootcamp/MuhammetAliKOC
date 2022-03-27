using First.App.Business.DTOs;
using HomeWork04_First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework04_First.App.Business.Abstract
{
    public interface IUserService
    {
        void AddUser(User user);

        List<UserDto> GetAllUser();

        bool CheckUser(string Email, string password);
    }
}
