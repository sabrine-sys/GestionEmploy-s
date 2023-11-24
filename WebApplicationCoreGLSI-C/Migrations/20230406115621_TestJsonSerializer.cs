using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_C.Migrations
{
    /// <inheritdoc />
    public partial class TestJsonSerializer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("b1f663bd-5435-4820-8c65-7787965a4a89"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("608d05d4-1513-49ef-a27f-a910b05f0213"), "SeedDataFromJsonFile" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("608d05d4-1513-49ef-a27f-a910b05f0213"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b1f663bd-5435-4820-8c65-7787965a4a89"), "Cat From APIFluent" });
        }
    }
}
