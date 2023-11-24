using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_C.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameCateg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "categories",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "ABC",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldDefaultValue: "ABC");
        }
    }
}
