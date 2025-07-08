using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 56, 58, 93, DateTimeKind.Utc).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 56, 58, 93, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 56, 58, 93, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 56, 58, 93, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 56, 58, 93, DateTimeKind.Utc).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 20, 15, 56, 58, 91, DateTimeKind.Utc).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 20, 15, 56, 58, 91, DateTimeKind.Utc).AddTicks(1115));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 48, 1, 280, DateTimeKind.Utc).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 48, 1, 281, DateTimeKind.Utc).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 48, 1, 281, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 48, 1, 281, DateTimeKind.Utc).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2025, 2, 20, 15, 48, 1, 281, DateTimeKind.Utc).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 20, 15, 48, 1, 278, DateTimeKind.Utc).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 20, 15, 48, 1, 278, DateTimeKind.Utc).AddTicks(7874));
        }
    }
}
