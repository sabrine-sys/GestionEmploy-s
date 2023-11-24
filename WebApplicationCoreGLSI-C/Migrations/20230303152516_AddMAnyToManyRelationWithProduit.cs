using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_C.Migrations
{
    /// <inheritdoc />
    public partial class AddMAnyToManyRelationWithProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProduitSousCategorie",
                columns: table => new
                {
                    produitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sousCatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitSousCategorie", x => new { x.produitsId, x.sousCatId });
                    table.ForeignKey(
                        name: "FK_ProduitSousCategorie_produits_produitsId",
                        column: x => x.produitsId,
                        principalTable: "produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitSousCategorie_sscategories_sousCatId",
                        column: x => x.sousCatId,
                        principalTable: "sscategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduitSousCategorie_sousCatId",
                table: "ProduitSousCategorie",
                column: "sousCatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduitSousCategorie");

            migrationBuilder.DropTable(
                name: "produits");
        }
    }
}
