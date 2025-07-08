using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddCarPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "DateAdded", "IsAvailable", "Make", "Model", "Picture", "RentalPricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, "White", new DateTime(2025, 2, 15, 5, 35, 32, 657, DateTimeKind.Utc).AddTicks(8282), true, "Toyota", "Corolla", "/pictures/Toyota-Corolla.jpg", 5000m, 2022 },
                    { 2, "Black", new DateTime(2025, 2, 15, 5, 35, 32, 657, DateTimeKind.Utc).AddTicks(8491), true, "Honda", "Civic", "/pictures/Honda-Civic.jpg", 5500m, 2023 },
                    { 3, "Red", new DateTime(2025, 2, 15, 5, 35, 32, 657, DateTimeKind.Utc).AddTicks(8494), true, "Ford", "Mustang", "/pictures/Ford-Mustang.jpg", 12000m, 2021 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 15, 5, 35, 32, 656, DateTimeKind.Utc).AddTicks(7575), "$2a$11$uivErZ8/jJFIH28eNsQQROgWqkL2iaryggOZ8LnflSb9xa5cZlxS2", "$2a$11$uivErZ8/jJFIH28eNsQQRO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 15, 4, 48, 59, 309, DateTimeKind.Utc).AddTicks(739), "$2a$11$ztqfJ8L1a0dX3.1NU6X3OeYtrvcgQuIIpzEnn3x3D1Jg1.UsujBlq", "$2a$11$ztqfJ8L1a0dX3.1NU6X3Oe" });
        }
    }
}
