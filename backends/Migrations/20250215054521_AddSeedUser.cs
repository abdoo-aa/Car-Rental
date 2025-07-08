using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddSeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 45, 20, 887, DateTimeKind.Utc).AddTicks(5085));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 45, 20, 887, DateTimeKind.Utc).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 45, 20, 887, DateTimeKind.Utc).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 15, 5, 45, 20, 886, DateTimeKind.Utc).AddTicks(4298), "$2a$11$asRY4oZ3L5DWc2sV.VBtnOhHVI2ngh0lLYyOQcvD04uuBxW3TOuey", "$2a$11$asRY4oZ3L5DWc2sV.VBtnO" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 2, new DateTime(2025, 2, 15, 5, 45, 20, 887, DateTimeKind.Utc).AddTicks(2637), "$2a$11$99DGr/A531y9H0ARnQ94eO4XSjWUwPAwcAyzcEF1ftwfKx5rIBF2C", "$2a$11$99DGr/A531y9H0ARnQ94eO", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 41, 51, 215, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 41, 51, 215, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 41, 51, 215, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 15, 5, 41, 51, 214, DateTimeKind.Utc).AddTicks(3589), "$2a$11$x7M/OYsTklPG2qnzeHQ0..uqz1rY0jcLQWW5Z5QrLL4Dy5bZ7GsPm", "$2a$11$x7M/OYsTklPG2qnzeHQ0.." });
        }
    }
}
