using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloodonor.Migrations
{
    public partial class sixt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "BloodGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BloodGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5dbf5a6e-33f1-4404-91e9-43734dded159", "AQAAAAEAACcQAAAAEHmsi9qrYkFzyHGr+3xMec2p/p6vBnCN/3CeQGSMfWmTF8Leh2GuUfQp49alx4Se1A==" });

            migrationBuilder.UpdateData(
                table: "BloodGroups",
                keyColumn: "BloodGroupId",
                keyValue: 1,
                columns: new[] { "LastUpdated", "Status" },
                values: new object[] { new DateTime(2023, 3, 18, 21, 44, 27, 260, DateTimeKind.Local).AddTicks(6357), "Enable" });

            migrationBuilder.UpdateData(
                table: "BloodGroups",
                keyColumn: "BloodGroupId",
                keyValue: 2,
                columns: new[] { "LastUpdated", "Status" },
                values: new object[] { new DateTime(2023, 3, 18, 21, 44, 27, 260, DateTimeKind.Local).AddTicks(6362), "Enable" });

            migrationBuilder.UpdateData(
                table: "BloodGroups",
                keyColumn: "BloodGroupId",
                keyValue: 3,
                columns: new[] { "LastUpdated", "Status" },
                values: new object[] { new DateTime(2023, 3, 18, 21, 44, 27, 260, DateTimeKind.Local).AddTicks(6367), "Enable" });

            migrationBuilder.UpdateData(
                table: "BloodGroups",
                keyColumn: "BloodGroupId",
                keyValue: 4,
                columns: new[] { "LastUpdated", "Status" },
                values: new object[] { new DateTime(2023, 3, 18, 21, 44, 27, 260, DateTimeKind.Local).AddTicks(6372), "Enable" });

            migrationBuilder.UpdateData(
                table: "BloodGroups",
                keyColumn: "BloodGroupId",
                keyValue: 5,
                columns: new[] { "LastUpdated", "Status" },
                values: new object[] { new DateTime(2023, 3, 18, 21, 44, 27, 260, DateTimeKind.Local).AddTicks(6376), "Enable" });

            migrationBuilder.UpdateData(
                table: "BloodGroups",
                keyColumn: "BloodGroupId",
                keyValue: 6,
                columns: new[] { "LastUpdated", "Status" },
                values: new object[] { new DateTime(2023, 3, 18, 21, 44, 27, 260, DateTimeKind.Local).AddTicks(6381), "Enable" });

            migrationBuilder.UpdateData(
                table: "BloodGroups",
                keyColumn: "BloodGroupId",
                keyValue: 7,
                columns: new[] { "LastUpdated", "Status" },
                values: new object[] { new DateTime(2023, 3, 18, 21, 44, 27, 260, DateTimeKind.Local).AddTicks(6385), "Enable" });

            migrationBuilder.UpdateData(
                table: "BloodGroups",
                keyColumn: "BloodGroupId",
                keyValue: 8,
                columns: new[] { "LastUpdated", "Status" },
                values: new object[] { new DateTime(2023, 3, 18, 21, 44, 27, 260, DateTimeKind.Local).AddTicks(6390), "Enable" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "BloodGroups");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BloodGroups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd2a66c1-f140-4a24-97c8-4706200546b0", "AQAAAAEAACcQAAAAECbkYT60lbz3XCJ+oaog70u5Q6qizSXtlro/TmYLlw1pQNnfJ5wZa0l8HX+YjpYyKw==" });
        }
    }
}
