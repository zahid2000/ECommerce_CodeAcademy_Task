﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    partial class ECommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("COGS")
                        .HasColumnType("float")
                        .HasColumnName("COGS");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Country");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("DiscountBand")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DiscountBand");

                    b.Property<double>("Discounts")
                        .HasColumnType("float")
                        .HasColumnName("Discounts");

                    b.Property<double>("GrossSales")
                        .HasColumnType("float")
                        .HasColumnName("GrossSales");

                    b.Property<double>("ManufacturingPrice")
                        .HasColumnType("float")
                        .HasColumnName("ManufacturingPrice");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Product");

                    b.Property<double>("Profit")
                        .HasColumnType("float")
                        .HasColumnName("Profit");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float")
                        .HasColumnName("SalePrice");

                    b.Property<double>("Sales")
                        .HasColumnType("float")
                        .HasColumnName("Sales");

                    b.Property<string>("Segment")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Segment");

                    b.Property<double>("UnitsSold")
                        .HasColumnType("float")
                        .HasColumnName("UnitsSold");

                    b.HasKey("Id");

                    b.ToTable("ProductDetails", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
