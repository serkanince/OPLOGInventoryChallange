using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OPLOGInventory.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dimension",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimension", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    x = table.Column<decimal>(nullable: false),
                    y = table.Column<decimal>(nullable: false),
                    z = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ReferanceNo = table.Column<string>(nullable: false),
                    IsShipped = table.Column<bool>(nullable: false),
                    CancelledDate = table.Column<DateTime>(nullable: true),
                    ShippedDate = table.Column<DateTime>(nullable: true),
                    ReceiverName = table.Column<string>(nullable: false),
                    ReceiverAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SKU = table.Column<string>(nullable: false),
                    DimensionId = table.Column<Guid>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Dimension_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimension",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Container_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    SalesOrderId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LineItem_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barcode",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Barcode_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    LineItemId = table.Column<Guid>(nullable: true),
                    ContainerId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Container_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Container",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItem_LineItem_LineItemId",
                        column: x => x.LineItemId,
                        principalTable: "LineItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApiUser",
                columns: new[] { "ID", "LastLogin", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("b0747458-b729-4730-8403-8bc199c913ae"), null, "seller", "Seller", "seller" },
                    { new Guid("74faa0bc-d011-4909-baf1-20c435567ba4"), null, "operator", "Operator", "operator" }
                });

            migrationBuilder.InsertData(
                table: "Dimension",
                columns: new[] { "ID", "Height", "Length", "ProductId", "Weight", "Width" },
                values: new object[] { new Guid("de21c3b4-ca18-4c30-8aac-8251630ee557"), 100m, 10m, new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"), 50m, 200m });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "ID", "x", "y", "z" },
                values: new object[,]
                {
                    { new Guid("b9ab31e1-4dc6-428c-9c76-825e8ddd553c"), 11m, 11m, 11m },
                    { new Guid("ab630a72-7ef7-4722-95c4-d9fb645f1f18"), 11m, 22m, 11m }
                });

            migrationBuilder.InsertData(
                table: "SalesOrder",
                columns: new[] { "ID", "CancelledDate", "IsShipped", "ReceiverAddress", "ReceiverName", "ReferanceNo", "ShippedDate" },
                values: new object[] { new Guid("959c9b75-641f-43b3-b90e-cef5bf0ecc36"), null, true, "Çankaya Ankara TR", "Serkan İnce", "SRK06", new DateTime(2021, 11, 9, 15, 1, 52, 977, DateTimeKind.Local).AddTicks(3714) });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "ID", "Label", "LocationId" },
                values: new object[,]
                {
                    { new Guid("ffcbd352-6d8a-4156-9e0c-2dd87ba39abf"), "Container-X", new Guid("b9ab31e1-4dc6-428c-9c76-825e8ddd553c") },
                    { new Guid("cea82f10-b321-4c9f-a0b6-5920eb9ffabb"), "Container-Y", new Guid("ab630a72-7ef7-4722-95c4-d9fb645f1f18") }
                });

            migrationBuilder.InsertData(
                table: "LineItem",
                columns: new[] { "ID", "ProductId", "Quantity", "SalesOrderId" },
                values: new object[] { new Guid("395a3b2f-0902-471a-8b2d-9c93ab84903b"), new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"), 1L, new Guid("959c9b75-641f-43b3-b90e-cef5bf0ecc36") });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "DimensionId", "ImageUrl", "Name", "SKU" },
                values: new object[,]
                {
                    { new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"), new Guid("de21c3b4-ca18-4c30-8aac-8251630ee557"), "image-url", "Coffee Mug Red, model no.1", "CM-1-R" },
                    { new Guid("dff9c6ba-9ab4-4b44-9466-6f4e94bf1439"), new Guid("de21c3b4-ca18-4c30-8aac-8251630ee557"), "image-url", "Coffee Cup Yellow, model no.5", "CC-5-Y" }
                });

            migrationBuilder.InsertData(
                table: "Barcode",
                columns: new[] { "ID", "Label", "ProductId" },
                values: new object[] { new Guid("865113a4-f11b-4844-ba2e-61df74c38a80"), "Barcode--1", new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf") });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "ID", "ContainerId", "LineItemId", "ProductId", "Type" },
                values: new object[,]
                {
                    { new Guid("9190943b-7e13-41ec-8c87-d557a3f67ef0"), new Guid("ffcbd352-6d8a-4156-9e0c-2dd87ba39abf"), null, new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"), 1 },
                    { new Guid("fef27c4c-411c-4ecb-a997-a6cd8dec2026"), new Guid("cea82f10-b321-4c9f-a0b6-5920eb9ffabb"), null, new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"), 1 },
                    { new Guid("76a721ad-2cc3-4475-9762-6c5cdf8eaa55"), new Guid("cea82f10-b321-4c9f-a0b6-5920eb9ffabb"), null, new Guid("dff9c6ba-9ab4-4b44-9466-6f4e94bf1439"), 1 },
                    { new Guid("03570478-a343-45f8-8a81-9567402320d4"), new Guid("cea82f10-b321-4c9f-a0b6-5920eb9ffabb"), null, new Guid("dff9c6ba-9ab4-4b44-9466-6f4e94bf1439"), 1 },
                    { new Guid("12c178c4-16a6-4a48-97aa-7e28921c9f3b"), new Guid("ffcbd352-6d8a-4156-9e0c-2dd87ba39abf"), new Guid("395a3b2f-0902-471a-8b2d-9c93ab84903b"), new Guid("2657c0bd-9cfc-4156-9cf0-a7e587eedfcf"), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_ProductId",
                table: "Barcode",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Container_Label",
                table: "Container",
                column: "Label");

            migrationBuilder.CreateIndex(
                name: "IX_Container_LocationId",
                table: "Container",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ContainerId",
                table: "InventoryItem",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_LineItemId",
                table: "InventoryItem",
                column: "LineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ProductId",
                table: "InventoryItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_SalesOrderId",
                table: "LineItem",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DimensionId",
                table: "Product",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SKU",
                table: "Product",
                column: "SKU");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_ReferanceNo",
                table: "SalesOrder",
                column: "ReferanceNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiUser");

            migrationBuilder.DropTable(
                name: "Barcode");

            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "Dimension");
        }
    }
}
