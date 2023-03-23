using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloodonor.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd2a66c1-f140-4a24-97c8-4706200546b0", "AQAAAAEAACcQAAAAECbkYT60lbz3XCJ+oaog70u5Q6qizSXtlro/TmYLlw1pQNnfJ5wZa0l8HX+YjpYyKw==" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Emaail", "LocationId", "Zonal_Director" },
                values: new object[] { 1, "nbtsowerri@gmail.com", 1, "Dr. Malachy Iheanacho" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Emaail", "LocationId", "Zonal_Director" },
                values: new object[] { 2, "nbts_swzib@yahoo.co.uk", 2, "Dr. Oladapo W. Aworanti" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e3502b1-44be-4dda-8a92-601479723b6d", "AQAAAAEAACcQAAAAEIeOS5/MvUK9sGnDgeBkr4/IU9RtmxIbUGaN7vIpL8WUjxxvO9bOw3NcytPVc7etmw==" });
        }
    }
}
