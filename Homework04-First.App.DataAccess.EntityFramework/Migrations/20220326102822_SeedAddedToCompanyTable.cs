using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Homework04_First.App.DataAccess.EntityFramework.Migrations
{
    public partial class SeedAddedToCompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "LastUpdatedAt", "LastUpdatedBy", "Location", "Name", "Phone" },
                values: new object[] { 1, "Kocaeli/İzmit", "Kocaeli", "Türkiye", new DateTime(2022, 3, 26, 13, 28, 21, 531, DateTimeKind.Local).AddTicks(639), "System", "Location bilgisi Güldür güldür Adana adliyesi skeçinden alınmıştır.", false, null, null, "Çarşı caddesi no:36, Camiyi geçince; dükkanın altıııı :)", "Tercanlar", "0555 555 55 55" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "LastUpdatedAt", "LastUpdatedBy", "Location", "Name", "Phone" },
                values: new object[] { 2, "İstanbul/Beşiktaş", "Kocaeli", "Türkiye", new DateTime(2022, 3, 26, 13, 28, 21, 532, DateTimeKind.Local).AddTicks(5773), "System", "Location bilgisi Güldür güldür Adana adliyesi skeçinden alınmıştır.", false, null, null, "Çarşı caddesi no:36, Camiyi geçince; dükkanın altıııı :) 2", "Tercanlar 2", "0553 333 33 33" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
