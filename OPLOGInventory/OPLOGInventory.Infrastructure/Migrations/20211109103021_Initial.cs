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
                    { new Guid("0df03e8e-6a12-4046-92e4-5243a00ea415"), null, "seller", "Seller", "seller" },
                    { new Guid("e5851510-c82c-47cc-aa78-7e22153d2049"), null, "operator", "Operator", "operator" }
                });

            migrationBuilder.InsertData(
                table: "Dimension",
                columns: new[] { "ID", "Height", "Length", "ProductId", "Weight", "Width" },
                values: new object[] { new Guid("8a3b3eb5-aa0d-442e-9e41-9b3b57f2dcc7"), 100m, 10m, new Guid("f68b5b5f-2e40-49ef-a7c0-32c5fb9509dc"), 50m, 200m });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "ID", "x", "y", "z" },
                values: new object[,]
                {
                    { new Guid("b1bd5849-6315-44af-8501-886fb041d98b"), 11m, 11m, 11m },
                    { new Guid("e55e43db-4b1f-4e94-bcf8-0e67639c0cae"), 11m, 22m, 11m }
                });

            migrationBuilder.InsertData(
                table: "SalesOrder",
                columns: new[] { "ID", "CancelledDate", "IsShipped", "ReceiverAddress", "ReceiverName", "ReferanceNo", "ShippedDate" },
                values: new object[] { new Guid("1906ce65-d328-4efb-878e-94bffcdeafe6"), null, true, "Çankaya Ankara TR", "Serkan İnce", "SRK06", new DateTime(2021, 11, 9, 13, 30, 20, 993, DateTimeKind.Local).AddTicks(9323) });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "ID", "Label", "LocationId" },
                values: new object[,]
                {
                    { new Guid("8ef1de11-f43c-47b8-b7c2-60edbb9a6e4f"), "Container-X", new Guid("b1bd5849-6315-44af-8501-886fb041d98b") },
                    { new Guid("1c3c35b4-f9e4-42ac-877d-c6512628a6ee"), "Container-Y", new Guid("e55e43db-4b1f-4e94-bcf8-0e67639c0cae") }
                });

            migrationBuilder.InsertData(
                table: "LineItem",
                columns: new[] { "ID", "ProductId", "Quantity", "SalesOrderId" },
                values: new object[] { new Guid("dffcff84-0115-410b-a3a6-ed1716ea30c2"), new Guid("f68b5b5f-2e40-49ef-a7c0-32c5fb9509dc"), 1L, new Guid("1906ce65-d328-4efb-878e-94bffcdeafe6") });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "DimensionId", "ImageUrl", "Name", "SKU" },
                values: new object[,]
                {
                    { new Guid("f68b5b5f-2e40-49ef-a7c0-32c5fb9509dc"), new Guid("8a3b3eb5-aa0d-442e-9e41-9b3b57f2dcc7"), "image-url", "Coffee Mug Red, model no.1", "CM-1-R" },
                    { new Guid("56350ff4-0c59-4336-b52f-2784b3748525"), new Guid("8a3b3eb5-aa0d-442e-9e41-9b3b57f2dcc7"), "image-url", "Coffee Cup Yellow, model no.5", "CC-5-Y" }
                });

            migrationBuilder.InsertData(
                table: "Barcode",
                columns: new[] { "ID", "Label", "ProductId" },
                values: new object[] { new Guid("3ec073f6-f0aa-4583-a287-d35b0d6d6dc3"), "Barcode--1", new Guid("f68b5b5f-2e40-49ef-a7c0-32c5fb9509dc") });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "ID", "ContainerId", "LineItemId", "ProductId", "Type" },
                values: new object[,]
                {
                    { new Guid("41f5fe6d-c34b-44e9-95b5-d541d3f71259"), new Guid("8ef1de11-f43c-47b8-b7c2-60edbb9a6e4f"), null, new Guid("f68b5b5f-2e40-49ef-a7c0-32c5fb9509dc"), 1 },
                    { new Guid("7005b649-0ce1-42cf-aebd-f38b99aaebd6"), new Guid("1c3c35b4-f9e4-42ac-877d-c6512628a6ee"), null, new Guid("f68b5b5f-2e40-49ef-a7c0-32c5fb9509dc"), 1 },
                    { new Guid("2073b3b9-69b8-4868-be06-22b936372224"), new Guid("1c3c35b4-f9e4-42ac-877d-c6512628a6ee"), null, new Guid("56350ff4-0c59-4336-b52f-2784b3748525"), 1 },
                    { new Guid("8fb89ae7-6bba-433d-94f8-3f2f0ca4d35d"), new Guid("1c3c35b4-f9e4-42ac-877d-c6512628a6ee"), null, new Guid("56350ff4-0c59-4336-b52f-2784b3748525"), 1 },
                    { new Guid("a43a103a-fa39-4c61-b306-e44ceb46ca92"), new Guid("8ef1de11-f43c-47b8-b7c2-60edbb9a6e4f"), new Guid("dffcff84-0115-410b-a3a6-ed1716ea30c2"), new Guid("f68b5b5f-2e40-49ef-a7c0-32c5fb9509dc"), 3 }
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
