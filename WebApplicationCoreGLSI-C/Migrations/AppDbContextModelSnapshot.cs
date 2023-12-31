﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationCoreGLSI_C.Models;

#nullable disable

namespace WebApplicationCoreGLSI_C.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProduitSousCategorie", b =>
                {
                    b.Property<Guid>("produitsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("sousCatId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("produitsId", "sousCatId");

                    b.HasIndex("sousCatId");

                    b.ToTable("ProduitSousCategorie");
                });

            modelBuilder.Entity("WebApplicationCoreGLSI_C.Models.Categorie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasDefaultValue("ABC");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("608d05d4-1513-49ef-a27f-a910b05f0213"),
                            Name = "SeedDataFromJsonFile"
                        });
                });

            modelBuilder.Entity("WebApplicationCoreGLSI_C.Models.Produit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateAjoutProduit")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("produits");
                });

            modelBuilder.Entity("WebApplicationCoreGLSI_C.Models.SousCategorie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategorieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SousCatName");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("sscategories");
                });

            modelBuilder.Entity("ProduitSousCategorie", b =>
                {
                    b.HasOne("WebApplicationCoreGLSI_C.Models.Produit", null)
                        .WithMany()
                        .HasForeignKey("produitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationCoreGLSI_C.Models.SousCategorie", null)
                        .WithMany()
                        .HasForeignKey("sousCatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationCoreGLSI_C.Models.SousCategorie", b =>
                {
                    b.HasOne("WebApplicationCoreGLSI_C.Models.Categorie", "categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categorie");
                });
#pragma warning restore 612, 618
        }
    }
}
