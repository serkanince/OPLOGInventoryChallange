﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Data.Migrations
{
    [DbContext(typeof(PostgreSqlDBContext))]
    partial class PostgreSqlDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OPLOGInventory.Data.Entity.ApiUser", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ApiUser");

                    b.HasData(
                        new
                        {
                            ID = new Guid("b0747458-b729-4730-8403-8bc199c913ae"),
                            Password = "seller",
                            Role = "Seller",
                            Username = "seller"
                        },
                        new
                        {
                            ID = new Guid("74faa0bc-d011-4909-baf1-20c435567ba4"),
                            Password = "operator",
                            Role = "Operator",
                            Username = "operator"
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.Barcode", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.ToTable("Barcode");

                    b.HasData(
                        new
                        {
                            ID = new Guid("865113a4-f11b-4844-ba2e-61df74c38a80"),
                            Label = "Barcode--1",
                            ProductId = new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf")
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.Container", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("Label");

                    b.HasIndex("LocationId");

                    b.ToTable("Container");

                    b.HasData(
                        new
                        {
                            ID = new Guid("ffcbd352-6d8a-4156-9e0c-2dd87ba39abf"),
                            Label = "Container-X",
                            LocationId = new Guid("b9ab31e1-4dc6-428c-9c76-825e8ddd553c")
                        },
                        new
                        {
                            ID = new Guid("cea82f10-b321-4c9f-a0b6-5920eb9ffabb"),
                            Label = "Container-Y",
                            LocationId = new Guid("ab630a72-7ef7-4722-95c4-d9fb645f1f18")
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.Dimension", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Height")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Length")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Width")
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.ToTable("Dimension");

                    b.HasData(
                        new
                        {
                            ID = new Guid("de21c3b4-ca18-4c30-8aac-8251630ee557"),
                            Height = 100m,
                            Length = 10m,
                            ProductId = new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"),
                            Weight = 50m,
                            Width = 200m
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.InventoryItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContainerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LineItemId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ContainerId");

                    b.HasIndex("LineItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("InventoryItem");

                    b.HasData(
                        new
                        {
                            ID = new Guid("12c178c4-16a6-4a48-97aa-7e28921c9f3b"),
                            ContainerId = new Guid("ffcbd352-6d8a-4156-9e0c-2dd87ba39abf"),
                            LineItemId = new Guid("395a3b2f-0902-471a-8b2d-9c93ab84903b"),
                            ProductId = new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"),
                            Type = 3
                        },
                        new
                        {
                            ID = new Guid("9190943b-7e13-41ec-8c87-d557a3f67ef0"),
                            ContainerId = new Guid("ffcbd352-6d8a-4156-9e0c-2dd87ba39abf"),
                            ProductId = new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"),
                            Type = 1
                        },
                        new
                        {
                            ID = new Guid("fef27c4c-411c-4ecb-a997-a6cd8dec2026"),
                            ContainerId = new Guid("cea82f10-b321-4c9f-a0b6-5920eb9ffabb"),
                            ProductId = new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"),
                            Type = 1
                        },
                        new
                        {
                            ID = new Guid("76a721ad-2cc3-4475-9762-6c5cdf8eaa55"),
                            ContainerId = new Guid("cea82f10-b321-4c9f-a0b6-5920eb9ffabb"),
                            ProductId = new Guid("dff9c6ba-9ab4-4b44-9466-6f4e94bf1439"),
                            Type = 1
                        },
                        new
                        {
                            ID = new Guid("03570478-a343-45f8-8a81-9567402320d4"),
                            ContainerId = new Guid("cea82f10-b321-4c9f-a0b6-5920eb9ffabb"),
                            ProductId = new Guid("dff9c6ba-9ab4-4b44-9466-6f4e94bf1439"),
                            Type = 1
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.LineItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SalesOrderId")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("LineItem");

                    b.HasData(
                        new
                        {
                            ID = new Guid("395a3b2f-0902-471a-8b2d-9c93ab84903b"),
                            ProductId = new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"),
                            Quantity = 1L,
                            SalesOrderId = new Guid("959c9b75-641f-43b3-b90e-cef5bf0ecc36")
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.Location", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("x")
                        .HasColumnType("numeric");

                    b.Property<decimal>("y")
                        .HasColumnType("numeric");

                    b.Property<decimal>("z")
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            ID = new Guid("b9ab31e1-4dc6-428c-9c76-825e8ddd553c"),
                            x = 11m,
                            y = 11m,
                            z = 11m
                        },
                        new
                        {
                            ID = new Guid("ab630a72-7ef7-4722-95c4-d9fb645f1f18"),
                            x = 11m,
                            y = 22m,
                            z = 11m
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DimensionId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("DimensionId");

                    b.HasIndex("SKU");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"),
                            DimensionId = new Guid("de21c3b4-ca18-4c30-8aac-8251630ee557"),
                            ImageUrl = "image-url",
                            Name = "Coffee Mug Red, model no.1",
                            SKU = "CM-1-R"
                        },
                        new
                        {
                            ID = new Guid("dff9c6ba-9ab4-4b44-9466-6f4e94bf1439"),
                            DimensionId = new Guid("de21c3b4-ca18-4c30-8aac-8251630ee557"),
                            ImageUrl = "image-url",
                            Name = "Coffee Cup Yellow, model no.5",
                            SKU = "CC-5-Y"
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.SalesOrder", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CancelledDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsShipped")
                        .HasColumnType("boolean");

                    b.Property<string>("ReceiverAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReferanceNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("ReferanceNo");

                    b.ToTable("SalesOrder");

                    b.HasData(
                        new
                        {
                            ID = new Guid("959c9b75-641f-43b3-b90e-cef5bf0ecc36"),
                            IsShipped = true,
                            ReceiverAddress = "Çankaya Ankara TR",
                            ReceiverName = "Serkan İnce",
                            ReferanceNo = "SRK06",
                            ShippedDate = new DateTime(2021, 11, 9, 15, 1, 52, 977, DateTimeKind.Local).AddTicks(3714)
                        });
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.Barcode", b =>
                {
                    b.HasOne("OPLOGInventory.Data.Entity.Product", "Product")
                        .WithMany("Barcodes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.Container", b =>
                {
                    b.HasOne("OPLOGInventory.Data.Entity.Location", "Location")
                        .WithMany("LocatedContainers")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.InventoryItem", b =>
                {
                    b.HasOne("OPLOGInventory.Data.Entity.Container", "Container")
                        .WithMany("Contents")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OPLOGInventory.Data.Entity.LineItem", "LineItem")
                        .WithMany("InventoryItem")
                        .HasForeignKey("LineItemId");

                    b.HasOne("OPLOGInventory.Data.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.LineItem", b =>
                {
                    b.HasOne("OPLOGInventory.Data.Entity.SalesOrder", "SalesOrder")
                        .WithMany("LineItems")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OPLOGInventory.Data.Entity.Product", b =>
                {
                    b.HasOne("OPLOGInventory.Data.Entity.Dimension", "Dimension")
                        .WithMany()
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
