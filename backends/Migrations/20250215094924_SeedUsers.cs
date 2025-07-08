using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 49, 24, 367, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 49, 24, 367, DateTimeKind.Utc).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 49, 24, 367, DateTimeKind.Utc).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 49, 24, 367, DateTimeKind.Utc).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 49, 24, 367, DateTimeKind.Utc).AddTicks(3345));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1000, new DateTime(2025, 2, 15, 9, 49, 24, 366, DateTimeKind.Utc).AddTicks(2841), "GD@Arhamkala2025madmin@123#AK", "Admin", "ArhamAdmin" },
                    { 2000, new DateTime(2025, 2, 15, 9, 49, 24, 366, DateTimeKind.Utc).AddTicks(3042), "GD@User2025@123#AK", "User", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 38, 37, 225, DateTimeKind.Utc).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 38, 37, 225, DateTimeKind.Utc).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 38, 37, 225, DateTimeKind.Utc).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 38, 37, 225, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 38, 37, 225, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 100, new DateTime(2025, 2, 15, 9, 38, 37, 224, DateTimeKind.Utc).AddTicks(2618), "$2a$11$NktOMPo6AYd.VsfIWCtt4upcQRE6Tr76S/83Ylg1/NDj..JXn7ypO", "Admin", "ArhamAdmin" },
                    { 200, new DateTime(2025, 2, 15, 9, 38, 37, 224, DateTimeKind.Utc).AddTicks(2786), "$2a$11$RSKU5ZyCgTX4zkv2jGKzHuiEWn47hZB/WgHMYI4uYRteoS6GNzDjK", "User", "User" }
                });
        }
    }
}
