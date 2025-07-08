using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class SeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 1, new DateTime(2025, 2, 15, 4, 43, 8, 921, DateTimeKind.Utc).AddTicks(2927), "$2a$11$QAH5aG3WFMNNeG7VdglLXOuYdZ0terq2JC3jeW/xju53EzZr3DOT2", "$2a$11$QAH5aG3WFMNNeG7VdglLXO", "Admin", "ArhamAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
