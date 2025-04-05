using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace real_estate.Migrations
{
    /// <inheritdoc />
    public partial class addNewPKinEstateTypeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_EstateTypes_EstateTypeName",
                table: "RealEstates");

            migrationBuilder.DropIndex(
                name: "IX_RealEstates_EstateTypeName",
                table: "RealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstateTypes",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "EstateTypeName",
                table: "RealEstates");

            migrationBuilder.AddColumn<int>(
                name: "EstateTypeId",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EstateTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstateTypes",
                table: "EstateTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_EstateTypeId",
                table: "RealEstates",
                column: "EstateTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_EstateTypes_EstateTypeId",
                table: "RealEstates",
                column: "EstateTypeId",
                principalTable: "EstateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_EstateTypes_EstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropIndex(
                name: "IX_RealEstates_EstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstateTypes",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "EstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EstateTypes");

            migrationBuilder.AddColumn<string>(
                name: "EstateTypeName",
                table: "RealEstates",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstateTypes",
                table: "EstateTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_EstateTypeName",
                table: "RealEstates",
                column: "EstateTypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_EstateTypes_EstateTypeName",
                table: "RealEstates",
                column: "EstateTypeName",
                principalTable: "EstateTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
