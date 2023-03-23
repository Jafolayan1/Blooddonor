using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloodonor.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zonal_Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Emaail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e3502b1-44be-4dda-8a92-601479723b6d", "AQAAAAEAACcQAAAAEIeOS5/MvUK9sGnDgeBkr4/IU9RtmxIbUGaN7vIpL8WUjxxvO9bOw3NcytPVc7etmw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_LocationId",
                table: "Branches",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c3d1436e-4445-48c6-ba93-db1ce3e450a2", "AQAAAAEAACcQAAAAEDGirDYKRazu0+cndW3cynExCle5/g+GGxHIcSX9e3kvMXjexUmyPLkO1/yw7MGkoA==" });
        }
    }
}
