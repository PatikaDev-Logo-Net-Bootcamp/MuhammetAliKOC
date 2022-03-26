using First.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace First.App.DataAccess.EntityFramework.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(SeedCompanies());
        }

        /*Uygulama ilk ayağa kaltığında tabloda olmasını istediğim verileri burada belirliyoruz.*/
        private List<Company> SeedCompanies()
        {
            var companyList = new List<Company>();
            Company company1 = new Company()
            {
                Id =1,
                Name = "Tercanlar",
                Address = "Kocaeli/İzmit",
                Country = "Türkiye",
                City = "Kocaeli",
                Phone = "0555 555 55 55",
                Location = "Çarşı caddesi no:36, Camiyi geçince; dükkanın altıııı :)",
                Description = "Location bilgisi Güldür güldür Adana adliyesi skeçinden alınmıştır.",
                CreatedAt = System.DateTime.Now,
                CreatedBy = "System",
                IsDeleted = false
            };
            companyList.Add(company1);

            Company company2 = new Company()
            {
                Id = 2,
                Name = "Tercanlar 2",
                Address = "İstanbul/Beşiktaş",
                Country = "Türkiye",
                City = "Kocaeli",
                Phone = "0553 333 33 33",
                Location = "Çarşı caddesi no:36, Camiyi geçince; dükkanın altıııı :) 2",
                Description = "Location bilgisi Güldür güldür Adana adliyesi skeçinden alınmıştır.",
                CreatedAt = System.DateTime.Now,
                CreatedBy = "System",
                IsDeleted = false
            };
            companyList.Add(company2);

            return companyList;

        }
    }
}
