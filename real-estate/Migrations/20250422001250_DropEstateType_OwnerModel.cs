using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace real_estate.Migrations
{
    /// <inheritdoc />
    public partial class DropEstateType_OwnerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_EstateTypes_EstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Owners_OwnerId",
                table: "RealEstates");

            migrationBuilder.DropTable(
                name: "EstateTypes");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_RealEstates_EstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropIndex(
                name: "IX_RealEstates_OwnerId",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "EstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "RealEstates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstateTypeId",
                table: "RealEstates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "RealEstates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_EstateTypeId",
                table: "RealEstates",
                column: "EstateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_OwnerId",
                table: "RealEstates",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_EstateTypes_EstateTypeId",
                table: "RealEstates",
                column: "EstateTypeId",
                principalTable: "EstateTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Owners_OwnerId",
                table: "RealEstates",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");
        }
    }
}
