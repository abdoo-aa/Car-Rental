using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class SeedUpdateCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 16, 9, 17, 37, 20, DateTimeKind.Utc).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 16, 9, 17, 37, 20, DateTimeKind.Utc).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 16, 9, 17, 37, 20, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAdded", "IsAvailable", "Picture" },
                values: new object[] { new DateTime(2025, 2, 16, 9, 17, 37, 20, DateTimeKind.Utc).AddTicks(1443), false, "/pictures/Tesla-Model3.jpeg" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAdded", "Picture" },
                values: new object[] { new DateTime(2025, 2, 16, 9, 17, 37, 20, DateTimeKind.Utc).AddTicks(1444), "/pictures/BMW-X5.jpeg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 16, 9, 17, 37, 19, DateTimeKind.Utc).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 16, 9, 17, 37, 19, DateTimeKind.Utc).AddTicks(2334));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "DateAdded", "IsAvailable", "Picture" },
                values: new object[] { new DateTime(2025, 2, 15, 9, 49, 24, 367, DateTimeKind.Utc).AddTicks(3343), true, "/pictures/Tesla-Model3.jpg" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAdded", "Picture" },
                values: new object[] { new DateTime(2025, 2, 15, 9, 49, 24, 367, DateTimeKind.Utc).AddTicks(3345), "/pictures/BMW-X5.jpg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 15, 9, 49, 24, 366, DateTimeKind.Utc).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 15, 9, 49, 24, 366, DateTimeKind.Utc).AddTicks(3042));
        }
    }
}
