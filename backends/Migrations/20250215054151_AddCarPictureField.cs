using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddCarPictureField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 35, 32, 657, DateTimeKind.Utc).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 35, 32, 657, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 5, 35, 32, 657, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 15, 5, 35, 32, 656, DateTimeKind.Utc).AddTicks(7575), "$2a$11$uivErZ8/jJFIH28eNsQQROgWqkL2iaryggOZ8LnflSb9xa5cZlxS2", "$2a$11$uivErZ8/jJFIH28eNsQQRO" });
        }
    }
}
