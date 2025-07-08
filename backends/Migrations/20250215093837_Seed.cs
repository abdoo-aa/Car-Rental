using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2025, 2, 15, 9, 36, 18, 242, DateTimeKind.Utc).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 36, 18, 242, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 36, 18, 242, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 36, 18, 242, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2025, 2, 15, 9, 36, 18, 242, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 15, 9, 36, 18, 240, DateTimeKind.Utc).AddTicks(9728), "$2a$11$nae1oqkScfsPUGiXiORz/Oco4NsGwii74isD6TAhIQ/cRLG2uDi8q", "Admin", "ArhamAdmin" },
                    { 2, new DateTime(2025, 2, 15, 9, 36, 18, 240, DateTimeKind.Utc).AddTicks(9888), "$2a$11$/0ipuYKzE77pIZh1w/.ywuOLNbxZVuznQjXIBZzagxkA6IpidZ9DW", "User", "User" }
                });
        }
    }
}
