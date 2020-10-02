using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentRentalSystem.Infrastructure.Common.Persistence.Migrations
{
    public partial class AddStatisticsAndApartmentAdViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pricePerMonth",
                table: "ApartmentAds",
                newName: "PricePerMonth");

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalApartmentAds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentAdViews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentAdId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    StatisticsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentAdViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentAdViews_ApartmentAds_ApartmentAdId",
                        column: x => x.ApartmentAdId,
                        principalTable: "ApartmentAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApartmentAdViews_Statistics_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApartmentAdViews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAdViews_ApartmentAdId",
                table: "ApartmentAdViews",
                column: "ApartmentAdId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAdViews_StatisticsId",
                table: "ApartmentAdViews",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAdViews_UserId",
                table: "ApartmentAdViews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentAdViews");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.RenameColumn(
                name: "PricePerMonth",
                table: "ApartmentAds",
                newName: "pricePerMonth");
        }
    }
}
