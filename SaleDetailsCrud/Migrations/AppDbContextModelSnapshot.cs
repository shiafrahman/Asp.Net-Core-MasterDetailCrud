﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaleDetailsCrud.Models;

#nullable disable

namespace SaleDetailsCrud.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SaleDetailsCrud.Models.SalesDetails", b =>
                {
                    b.Property<int>("SalesDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesDetailsId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SalesMasterId")
                        .HasColumnType("int");

                    b.HasKey("SalesDetailsId");

                    b.HasIndex("SalesMasterId");

                    b.ToTable("SalesDetails");
                });

            modelBuilder.Entity("SaleDetailsCrud.Models.SalesMaster", b =>
                {
                    b.Property<int>("SalesMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesMasterId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalesDetailsId")
                        .HasColumnType("int");

                    b.HasKey("SalesMasterId");

                    b.ToTable("SalesMasters");
                });

            modelBuilder.Entity("SaleDetailsCrud.Models.SalesDetails", b =>
                {
                    b.HasOne("SaleDetailsCrud.Models.SalesMaster", "SalesMaster")
                        .WithMany("SalesDetails")
                        .HasForeignKey("SalesMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesMaster");
                });

            modelBuilder.Entity("SaleDetailsCrud.Models.SalesMaster", b =>
                {
                    b.Navigation("SalesDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
