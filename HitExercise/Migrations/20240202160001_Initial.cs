using Microsoft.EntityFrameworkCore.Migrations;

namespace HitExercise.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Afm = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryCode", "Name" },
                values: new object[,]
                {
                    { 1, 110, "Food-Supply" },
                    { 2, 120, "Room-Equipment" },
                    { 3, 130, "Electronic-Equipment" },
                    { 4, 140, "Medical-Equipment" },
                    { 5, 150, "Garden-Equipment" },
                    { 6, 160, "Pool-Equipment" },
                    { 7, 170, "FireSecurity-Equipment" },
                    { 8, 180, "Plumber-Equipment" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "Name" },
                values: new object[,]
                {
                    { 15, 1350, "Morroco" },
                    { 16, 1360, "Netherlands" },
                    { 17, 1370, "Pakistan" },
                    { 18, 1380, "Portugal" },
                    { 22, 1420, "Turkey" },
                    { 20, 1400, "Spain" },
                    { 21, 1410, "Sweeden" },
                    { 14, 1340, "Malaysia" },
                    { 23, 1430, "USA" },
                    { 19, 1390, "Russia" },
                    { 13, 1330, "Japan" },
                    { 9, 1290, "Germany" },
                    { 11, 1310, "India" },
                    { 10, 1300, "Greece" },
                    { 24, 1440, "United Kingdom" },
                    { 8, 1280, "France" },
                    { 7, 1270, "Egypt" },
                    { 6, 1260, "Denmark" },
                    { 5, 1250, "Chile" },
                    { 4, 1240, "China" },
                    { 3, 1230, "Belgium" },
                    { 2, 1220, "Bangladesh" },
                    { 1, 1210, "Argentina" },
                    { 12, 1320, "Italy" },
                    { 25, 1450, "Venezuela" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CategoryId",
                table: "Suppliers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryId",
                table: "Suppliers",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
