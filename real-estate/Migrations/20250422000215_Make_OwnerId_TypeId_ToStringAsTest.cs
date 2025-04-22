using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace real_estate.Migrations
{
    /// <inheritdoc />
    public partial class Make_OwnerId_TypeId_ToStringAsTest : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "RealEstates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EstateTypeId",
                table: "RealEstates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EstateType",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_EstateTypes_EstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Owners_OwnerId",
                table: "RealEstates");

            migrationBuilder.DropTable(
                name: "RealEstateImages");

            migrationBuilder.DropColumn(
                name: "EstateType",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "RealEstates");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstateTypeId",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_EstateTypes_EstateTypeId",
                table: "RealEstates",
                column: "EstateTypeId",
                principalTable: "EstateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Owners_OwnerId",
                table: "RealEstates",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
