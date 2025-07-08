using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

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

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "DateAdded", "IsAvailable", "Make", "Model", "Picture", "RentalPricePerDay", "Year" },
                values: new object[,]
                {
                    { 4, "Blue", new DateTime(2025, 2, 15, 9, 36, 18, 242, DateTimeKind.Utc).AddTicks(5409), true, "Tesla", "Model 3", "/pictures/Tesla-Model3.jpg", 7000m, 2024 },
                    { 5, "Grey", new DateTime(2025, 2, 15, 9, 36, 18, 242, DateTimeKind.Utc).AddTicks(5411), true, "BMW", "X5", "/pictures/BMW-X5.jpg", 9000m, 2022 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2025, 2, 15, 9, 36, 18, 240, DateTimeKind.Utc).AddTicks(9728), "$2a$11$nae1oqkScfsPUGiXiORz/Oco4NsGwii74isD6TAhIQ/cRLG2uDi8q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2025, 2, 15, 9, 36, 18, 240, DateTimeKind.Utc).AddTicks(9888), "$2a$11$/0ipuYKzE77pIZh1w/.ywuOLNbxZVuznQjXIBZzagxkA6IpidZ9DW" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 15, 5, 45, 20, 887, DateTimeKind.Utc).AddTicks(2637), "$2a$11$99DGr/A531y9H0ARnQ94eO4XSjWUwPAwcAyzcEF1ftwfKx5rIBF2C", "$2a$11$99DGr/A531y9H0ARnQ94eO" });
        }
    }
}
