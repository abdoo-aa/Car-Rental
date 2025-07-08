using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class SeedUpdateCarPic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 16, 9, 19, 4, 67, DateTimeKind.Utc).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 16, 9, 19, 4, 67, DateTimeKind.Utc).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2025, 2, 16, 9, 19, 4, 67, DateTimeKind.Utc).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAdded", "Picture" },
                values: new object[] { new DateTime(2025, 2, 16, 9, 19, 4, 67, DateTimeKind.Utc).AddTicks(7988), "/pictures/Tesla-Model3.jpg" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAdded", "Picture" },
                values: new object[] { new DateTime(2025, 2, 16, 9, 19, 4, 67, DateTimeKind.Utc).AddTicks(7990), "/pictures/BMW-X5.jpg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 16, 9, 19, 4, 66, DateTimeKind.Utc).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2000,
                column: "DateCreated",
                value: new DateTime(2025, 2, 16, 9, 19, 4, 66, DateTimeKind.Utc).AddTicks(8714));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "DateAdded", "Picture" },
                values: new object[] { new DateTime(2025, 2, 16, 9, 17, 37, 20, DateTimeKind.Utc).AddTicks(1443), "/pictures/Tesla-Model3.jpeg" });

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
    }
}
