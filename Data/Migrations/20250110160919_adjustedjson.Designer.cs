﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eshop.api.Data;

#nullable disable

namespace eshop.api.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250110160919_adjustedjson")]
    partial class adjustedjson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("eshop.api.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemNumber")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eshop.api.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SupplierAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierContact")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierName")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierPhone")
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("eshop.api.Entities.SupplierProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierProducts");
                });

            modelBuilder.Entity("eshop.api.Entities.SupplierProduct", b =>
                {
                    b.HasOne("eshop.api.Entities.Product", "Product")
                        .WithMany("SupplierProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eshop.api.Entities.Supplier", "Supplier")
                        .WithMany("SupplierProducts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("eshop.api.Entities.Product", b =>
                {
                    b.Navigation("SupplierProducts");
                });

            modelBuilder.Entity("eshop.api.Entities.Supplier", b =>
                {
                    b.Navigation("SupplierProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
