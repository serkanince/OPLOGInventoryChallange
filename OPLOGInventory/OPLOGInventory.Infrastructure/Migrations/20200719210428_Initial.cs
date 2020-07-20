using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OPLOGInventory.Infrastructure.Migrations
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
                    { new Guid("acc22dfe-0f3d-4dd4-914b-b8d0437a0d36"), null, "seller", "Seller", "seller" },
                    { new Guid("6d472649-123b-4f67-bba2-b2b8005a5fb1"), null, "operator", "Operator", "operator" }
                });

            migrationBuilder.InsertData(
                table: "Dimension",
                columns: new[] { "ID", "Height", "Length", "ProductId", "Weight", "Width" },
                values: new object[] { new Guid("921d4aee-7c99-4ffb-bdbb-d77c3bf882d7"), 100m, 10m, new Guid("feee0d3a-97b0-4963-b6fd-3050133f6058"), 50m, 200m });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "ID", "x", "y", "z" },
                values: new object[,]
                {
                    { new Guid("ee63ac91-eb6a-4ffd-ae74-87fac0f6069c"), 11m, 11m, 11m },
                    { new Guid("eee32b86-f018-4881-bb65-94fbfd17429a"), 11m, 22m, 11m }
                });

            migrationBuilder.InsertData(
                table: "SalesOrder",
                columns: new[] { "ID", "CancelledDate", "IsShipped", "ReceiverAddress", "ReceiverName", "ReferanceNo", "ShippedDate" },
                values: new object[] { new Guid("164362cc-9b19-4b62-a9ac-07b8927a5a1c"), null, true, "Çankaya Ankara TR", "Serkan İnce", "SRK06", new DateTime(2020, 7, 20, 0, 4, 28, 69, DateTimeKind.Local).AddTicks(8421) });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "ID", "Label", "LocationId" },
                values: new object[,]
                {
                    { new Guid("c42e807f-8c9e-414a-bf42-385f648fff2c"), "Container-X", new Guid("ee63ac91-eb6a-4ffd-ae74-87fac0f6069c") },
                    { new Guid("54218183-ce7e-4c9c-b87c-9a277e708fb4"), "Container-Y", new Guid("eee32b86-f018-4881-bb65-94fbfd17429a") }
                });

            migrationBuilder.InsertData(
                table: "LineItem",
                columns: new[] { "ID", "ProductId", "Quantity", "SalesOrderId" },
                values: new object[] { new Guid("76bd9f35-3415-45d4-a171-70f846f2d140"), new Guid("feee0d3a-97b0-4963-b6fd-3050133f6058"), 1L, new Guid("164362cc-9b19-4b62-a9ac-07b8927a5a1c") });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "DimensionId", "ImageUrl", "Name", "SKU" },
                values: new object[,]
                {
                    { new Guid("feee0d3a-97b0-4963-b6fd-3050133f6058"), new Guid("921d4aee-7c99-4ffb-bdbb-d77c3bf882d7"), "image-url", "Coffee Mug Red, model no.1", "CM-1-R" },
                    { new Guid("37f2c089-31d9-4baf-b547-4feab93588e1"), new Guid("921d4aee-7c99-4ffb-bdbb-d77c3bf882d7"), "image-url", "Coffee Cup Yellow, model no.5", "CC-5-Y" }
                });

            migrationBuilder.InsertData(
                table: "Barcode",
                columns: new[] { "ID", "Label", "ProductId" },
                values: new object[] { new Guid("b8c63ba9-8a85-4df6-9f78-211a073ea597"), "Barcode--1", new Guid("feee0d3a-97b0-4963-b6fd-3050133f6058") });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "ID", "ContainerId", "LineItemId", "ProductId", "Type" },
                values: new object[,]
                {
                    { new Guid("cd8ab84e-1eac-4542-a53f-58cac95b6cff"), new Guid("c42e807f-8c9e-414a-bf42-385f648fff2c"), null, new Guid("feee0d3a-97b0-4963-b6fd-3050133f6058"), 1 },
                    { new Guid("7ac47c36-6b2a-45d9-b1c8-466919185858"), new Guid("54218183-ce7e-4c9c-b87c-9a277e708fb4"), null, new Guid("feee0d3a-97b0-4963-b6fd-3050133f6058"), 1 },
                    { new Guid("c16d79cf-6511-455f-9c64-0ccf6e55bd09"), new Guid("54218183-ce7e-4c9c-b87c-9a277e708fb4"), null, new Guid("37f2c089-31d9-4baf-b547-4feab93588e1"), 1 },
                    { new Guid("c24b3ea1-9df2-44dd-bcf5-9d6dc3f4d26f"), new Guid("54218183-ce7e-4c9c-b87c-9a277e708fb4"), null, new Guid("37f2c089-31d9-4baf-b547-4feab93588e1"), 1 },
                    { new Guid("b26b0aec-369c-47e5-8e23-b5b150eb8a29"), new Guid("c42e807f-8c9e-414a-bf42-385f648fff2c"), new Guid("76bd9f35-3415-45d4-a171-70f846f2d140"), new Guid("feee0d3a-97b0-4963-b6fd-3050133f6058"), 3 }
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
