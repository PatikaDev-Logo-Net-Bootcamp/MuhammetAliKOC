using First.App.Domain.Entities;
using HomeWork04_First.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace First.App.DataAccess.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(SeedCompanies());
        }

        /*Uygulama ilk ayağa kaltığında tabloda olmasını istediğim verileri burada belirliyoruz.*/
        private List<User> SeedCompanies()
        {
            var userList = new List<User>();
            User user1 = new User()
            {
                Id =1,
                Name = "Muhammet Ali",
                Surname = "KOÇ",
                Email = "malikoc2020@gmail.com",
                Password = "hKaoJdFbclk=",/*123456*/
                CompanyId = 1,
                CreatedAt = System.DateTime.Now,
                CreatedBy = "System",
                IsDeleted = false
            };
            userList.Add(user1);

            User user2 = new User()
            {
                Id = 2,
                Name = "Eric",
                Surname = "ADDAI",
                Email = "eric@gmail.com",
                Password = "hKaoJdFbclk=",/*123456*/
                CompanyId = 2,
                CreatedAt = System.DateTime.Now,
                CreatedBy = "System",
                IsDeleted = false
            };
            userList.Add(user2);

            return userList;

        }
    }
}
