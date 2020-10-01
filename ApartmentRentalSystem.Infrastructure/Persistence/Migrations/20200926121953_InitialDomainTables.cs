using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentRentalSystem.Infrastructure.Persistence.Migrations
{
    public partial class InitialDomainTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brokers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber_Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentAds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 2048, nullable: false),
                    pricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Options_HasParking = table.Column<bool>(nullable: true),
                    Options_HasBasement = table.Column<bool>(nullable: true),
                    Options_HeatingType_Value = table.Column<int>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    BrokerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentAds_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApartmentAds_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApartmentAds_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAds_BrokerId",
                table: "ApartmentAds",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAds_CategoryId",
                table: "ApartmentAds",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAds_NeighborhoodId",
                table: "ApartmentAds",
                column: "NeighborhoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentAds");

            migrationBuilder.DropTable(
                name: "Brokers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Neighborhoods");
        }
    }
}
