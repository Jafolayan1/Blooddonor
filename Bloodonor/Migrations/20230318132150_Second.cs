using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloodonor.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "240425dd-bd7a-4c87-bbe5-25f3363e795f", "AQAAAAEAACcQAAAAEOQftizUL24LKwV7FZVqF5Jai/27Gurfmf7c1eRvVdTrIXrJJAvL+lKdVqumxpxaFQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1595e375-eb81-43cf-b7f1-2fad3454a347", "AQAAAAEAACcQAAAAEILWIdPCW3e6QPkeUjgffFMmz2Qww4WAlS25/o9FBZD6JsG4RpiYvMPdQUCUFNsSTQ==" });
        }
    }
}
