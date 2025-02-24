﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eshop.api.Data;

#nullable disable

namespace eshop.api.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250224170832_FixedOrderItems")]
    partial class FixedOrderItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("eshop.api.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine")
                        .HasColumnType("TEXT");

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostalAddressId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("PostalAddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("eshop.api.Entities.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("eshop.api.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("eshop.api.Entities.CustomerAddress", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddressId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("eshop.api.Entities.OrderItem", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SalesOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId", "SalesOrderId");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("eshop.api.Entities.PostalAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PostalAddresses");
                });

            modelBuilder.Entity("eshop.api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BestBeforeDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Weight")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eshop.api.Entities.SalesOrder", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.HasKey("SalesOrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("SalesOrders");
                });

            modelBuilder.Entity("eshop.api.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("eshop.api.Entities.SupplierAddress", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddressId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierAddresses");
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

            modelBuilder.Entity("eshop.api.Entities.Address", b =>
                {
                    b.HasOne("eshop.api.Entities.AddressType", "AddressType")
                        .WithMany("Addresses")
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eshop.api.Entities.PostalAddress", "PostalAddress")
                        .WithMany("Addresses")
                        .HasForeignKey("PostalAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressType");

                    b.Navigation("PostalAddress");
                });

            modelBuilder.Entity("eshop.api.Entities.CustomerAddress", b =>
                {
                    b.HasOne("eshop.api.Entities.Address", "Address")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eshop.api.Entities.Customer", "Customer")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("eshop.api.Entities.OrderItem", b =>
                {
                    b.HasOne("eshop.api.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eshop.api.Entities.SalesOrder", "SalesOrder")
                        .WithMany("OrderItems")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SalesOrder");
                });

            modelBuilder.Entity("eshop.api.Entities.SalesOrder", b =>
                {
                    b.HasOne("eshop.api.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("eshop.api.Entities.SupplierAddress", b =>
                {
                    b.HasOne("eshop.api.Entities.Address", "Address")
                        .WithMany("SupplierAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eshop.api.Entities.Supplier", "Supplier")
                        .WithMany("SupplierAddresses")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Supplier");
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

            modelBuilder.Entity("eshop.api.Entities.Address", b =>
                {
                    b.Navigation("CustomerAddresses");

                    b.Navigation("SupplierAddresses");
                });

            modelBuilder.Entity("eshop.api.Entities.AddressType", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("eshop.api.Entities.Customer", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("eshop.api.Entities.PostalAddress", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("eshop.api.Entities.Product", b =>
                {
                    b.Navigation("SupplierProducts");
                });

            modelBuilder.Entity("eshop.api.Entities.SalesOrder", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("eshop.api.Entities.Supplier", b =>
                {
                    b.Navigation("SupplierAddresses");

                    b.Navigation("SupplierProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
