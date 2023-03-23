using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloodonor.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c3d1436e-4445-48c6-ba93-db1ce3e450a2", "AQAAAAEAACcQAAAAEDGirDYKRazu0+cndW3cynExCle5/g+GGxHIcSX9e3kvMXjexUmyPLkO1/yw7MGkoA==" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "Imo" },
                    { 2, "Ibadan" },
                    { 3, "Plateau" },
                    { 4, "Kaduna" },
                    { 5, "Benin-City" },
                    { 6, "Maiduguri" },
                    { 7, "Port-Harcourt" },
                    { 8, "Ogun State" },
                    { 9, "Lokoja" },
                    { 10, "Yobe State" },
                    { 11, "Katsina. " },
                    { 12, "Ado-Ekiti " },
                    { 13, "Enugu State" },
                    { 14, "Taraba State" },
                    { 15, "Cross-River State " },
                    { 16, "Sokoto." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "240425dd-bd7a-4c87-bbe5-25f3363e795f", "AQAAAAEAACcQAAAAEOQftizUL24LKwV7FZVqF5Jai/27Gurfmf7c1eRvVdTrIXrJJAvL+lKdVqumxpxaFQ==" });
        }
    }
}
