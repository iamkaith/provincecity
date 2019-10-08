using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvinceCity.Data.Migrations.M1
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceCode = table.Column<string>(maxLength: 2, nullable: false),
                    ProvinceName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceCode);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: false),
                    Population = table.Column<int>(nullable: false),
                    ProvinceCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "Province",
                        principalColumn: "ProvinceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceCode", "ProvinceName" },
                values: new object[,]
                {
                    { "BC", "British Columbia" },
                    { "AB", "Alberta" },
                    { "SA", "Saskachewan" },
                    { "ON", "Ontario" },
                    { "NV", "Nova Scotia" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityName", "Population", "ProvinceCode" },
                values: new object[,]
                {
                    { 1, "Vancouver", 675218, "BC" },
                    { 2, "Burnaby", 249197, "BC" },
                    { 3, "Surrey", 518467, "BC" },
                    { 4, "Edmonton", 981280, "AB" },
                    { 5, "Calgary", 1336000, "AB" },
                    { 6, "Red Deer", 100418, "AB" },
                    { 7, "Toronto", 2731571, "ON" },
                    { 8, "Ottawa", 964743, "ON" },
                    { 9, "Mississauga", 721599, "ON" },
                    { 10, "Halifax", 403131, "NV" },
                    { 11, "Cape Breton", 94285, "NV" },
                    { 12, "Truro", 12261, "NV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceCode",
                table: "City",
                column: "ProvinceCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
