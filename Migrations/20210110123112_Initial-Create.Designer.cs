﻿// <auto-generated />
using System;
using Chisu_Diana_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chisu_Diana_Proiect.Migrations
{
    [DbContext(typeof(Chisu_Diana_ProiectContext))]
    [Migration("20210110123112_Initial-Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chisu_Diana_Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Chisu_Diana_Proiect.Models.Description", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Description");
                });

            modelBuilder.Entity("Chisu_Diana_Proiect.Models.Plant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DescriptionID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasMaxLength(50);

                    b.Property<int>("ShopID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DescriptionID");

                    b.HasIndex("ShopID");

                    b.ToTable("Plant");
                });

            modelBuilder.Entity("Chisu_Diana_Proiect.Models.PlantCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("PlantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PlantID");

                    b.ToTable("PlantCategory");
                });

            modelBuilder.Entity("Chisu_Diana_Proiect.Models.Shop", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShopName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("Chisu_Diana_Proiect.Models.Plant", b =>
                {
                    b.HasOne("Chisu_Diana_Proiect.Models.Description", null)
                        .WithMany("Plants")
                        .HasForeignKey("DescriptionID");

                    b.HasOne("Chisu_Diana_Proiect.Models.Shop", "Shop")
                        .WithMany("Plants")
                        .HasForeignKey("ShopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chisu_Diana_Proiect.Models.PlantCategory", b =>
                {
                    b.HasOne("Chisu_Diana_Proiect.Models.Category", "Category")
                        .WithMany("PlantCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chisu_Diana_Proiect.Models.Plant", "Plant")
                        .WithMany("PlantCategories")
                        .HasForeignKey("PlantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
