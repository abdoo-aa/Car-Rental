using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class UpdateBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarDetails_CarId",
                table: "CarDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 23, 5, 47, 23, 774, DateTimeKind.Utc).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 23, 5, 47, 23, 774, DateTimeKind.Utc).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 23, 5, 47, 23, 774, DateTimeKind.Utc).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2025, 2, 23, 5, 47, 23, 774, DateTimeKind.Utc).AddTicks(659));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2025, 2, 23, 5, 47, 23, 774, DateTimeKind.Utc).AddTicks(662));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 23, 5, 47, 23, 772, DateTimeKind.Utc).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 23, 5, 47, 23, 772, DateTimeKind.Utc).AddTicks(3449));

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_CarId",
                table: "CarDetails",
                column: "CarId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarDetails_CarId",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Bookings");

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

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_CarId",
                table: "CarDetails",
                column: "CarId");
        }
    }
}
