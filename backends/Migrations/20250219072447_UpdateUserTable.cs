using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Report",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 19, 7, 24, 47, 431, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 19, 7, 24, 47, 431, DateTimeKind.Utc).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 19, 7, 24, 47, 431, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2025, 2, 19, 7, 24, 47, 431, DateTimeKind.Utc).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2025, 2, 19, 7, 24, 47, 431, DateTimeKind.Utc).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000,
                columns: new[] { "DateCreated", "Email" },
                values: new object[] { new DateTime(2025, 2, 19, 7, 24, 47, 430, DateTimeKind.Utc).AddTicks(4023), "arhamkalam@admin.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000,
                columns: new[] { "DateCreated", "Email" },
                values: new object[] { new DateTime(2025, 2, 19, 7, 24, 47, 430, DateTimeKind.Utc).AddTicks(4181), "user@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Report",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 17, 9, 9, 30, 965, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 17, 9, 9, 30, 965, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 17, 9, 9, 30, 965, DateTimeKind.Utc).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2025, 2, 17, 9, 9, 30, 965, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2025, 2, 17, 9, 9, 30, 965, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 17, 9, 9, 30, 964, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 17, 9, 9, 30, 964, DateTimeKind.Utc).AddTicks(6410));
        }
    }
}
