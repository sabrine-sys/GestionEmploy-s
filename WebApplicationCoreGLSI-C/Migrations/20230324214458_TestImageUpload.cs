using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_C.Migrations
{
    /// <inheritdoc />
    public partial class TestImageUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileImage",
                table: "produits",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileImage",
                table: "produits");
        }
    }
}
