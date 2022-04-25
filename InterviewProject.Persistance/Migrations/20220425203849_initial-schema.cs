using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewProject.Persistence.Migrations
{
    public partial class initialschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Borders",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NeighbourId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borders", x => new { x.CountryId, x.NeighbourId });
                    table.ForeignKey(
                        name: "FK_Borders_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Borders_Countries_NeighbourId",
                        column: x => x.NeighbourId,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "BLZ", "Belize" },
                    { "CAN", "Canada" },
                    { "CRI", "Costa Rica" },
                    { "GTM", "Guatemala" },
                    { "HND", "Honduras" },
                    { "MEX", "Mexico" },
                    { "NIC", "Nicaragua" },
                    { "PAN", "Panama" },
                    { "SLV", "El Salvador" },
                    { "USA", "United States" }
                });

            migrationBuilder.InsertData(
                table: "Borders",
                columns: new[] { "CountryId", "NeighbourId" },
                values: new object[,]
                {
                    { "BLZ", "GTM" },
                    { "BLZ", "MEX" },
                    { "CAN", "USA" },
                    { "CRI", "NIC" },
                    { "CRI", "PAN" },
                    { "GTM", "BLZ" },
                    { "GTM", "HND" },
                    { "GTM", "MEX" },
                    { "GTM", "SLV" },
                    { "HND", "GTM" },
                    { "HND", "NIC" },
                    { "HND", "SLV" },
                    { "MEX", "BLZ" },
                    { "MEX", "GTM" },
                    { "MEX", "USA" },
                    { "NIC", "CRI" },
                    { "NIC", "SLV" },
                    { "PAN", "CRI" },
                    { "SLV", "GTM" },
                    { "SLV", "HND" },
                    { "USA", "CAN" },
                    { "USA", "MEX" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borders_NeighbourId",
                table: "Borders",
                column: "NeighbourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borders");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
