using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_C.Migrations
{
    /// <inheritdoc />
    public partial class testSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "sscategories",
                newName: "SousCatName");

            migrationBuilder.AlterColumn<string>(
                name: "SousCatName",
                table: "sscategories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b1f663bd-5435-4820-8c65-7787965a4a89"), "Cat From APIFluent" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("b1f663bd-5435-4820-8c65-7787965a4a89"));

            migrationBuilder.RenameColumn(
                name: "SousCatName",
                table: "sscategories",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "sscategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
