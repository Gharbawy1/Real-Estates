using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace real_estate.Migrations
{
    /// <inheritdoc />
    public partial class AddUploadImageLogicAndDeleteImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "RealEstates");

            migrationBuilder.CreateTable(
                name: "RealEstateImages",
                columns: table => new
                {
                    PublicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateImages", x => x.PublicId);
                    table.ForeignKey(
                        name: "FK_RealEstateImages_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateImages_RealEstateId",
                table: "RealEstateImages",
                column: "RealEstateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateImages");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
