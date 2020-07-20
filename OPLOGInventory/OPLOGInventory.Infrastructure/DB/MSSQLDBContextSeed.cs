using Microsoft.EntityFrameworkCore;
using OPLOGInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Infrastructure.DB
{
    public static class MSSQLDBContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.generateData();
        }

        private static void generateData(this ModelBuilder builder)
        {
            var locationGuid = Guid.NewGuid();
            var locationGuid_2 = Guid.NewGuid();
            var containerGuid = Guid.NewGuid();
            var containerGuid_2 = Guid.NewGuid();
            var inventoryGuid = Guid.NewGuid();
            var inventoryGuid_2 = Guid.NewGuid();
            var inventoryGuid_3 = Guid.NewGuid();
            var inventoryGuid_4 = Guid.NewGuid();
            var inventoryGuid_5 = Guid.NewGuid();
            var productID = Guid.NewGuid();
            var productID_2 = Guid.NewGuid();
            var dimensionId = Guid.NewGuid();
            var barcodeId = Guid.NewGuid();
            var salesOrderId = Guid.NewGuid();
            var lineItemId = Guid.NewGuid();
            var apiuserId = Guid.NewGuid();
            var apiuserId_2 = Guid.NewGuid();

            builder.Entity<Product>().HasData(new Product() { ID = productID, ImageUrl = "image-url", SKU = "CM-1-R", Name = "Coffee Mug Red, model no.1", DimensionId = dimensionId });
            builder.Entity<Product>().HasData(new Product() { ID = productID_2, ImageUrl = "image-url", SKU = "CC-5-Y", Name = "Coffee Cup Yellow, model no.5", DimensionId = dimensionId });
            builder.Entity<Dimension>().HasData(new Dimension() { ID = dimensionId, ProductId = productID, Height = 100, Length = 10, Weight = 50, Width = 200 });
            builder.Entity<Barcode>().HasData(new Barcode() { ID = barcodeId, ProductId = productID, Label = "Barcode--1" });
            builder.Entity<SalesOrder>().HasData(new SalesOrder() { ID = salesOrderId, IsShipped = true, ReceiverAddress = "Çankaya Ankara TR", ReceiverName = "Serkan İnce", ReferanceNo = "SRK06", ShippedDate = DateTime.Now });
            builder.Entity<LineItem>().HasData(new LineItem() { ID = lineItemId, ProductId = productID, SalesOrderId = salesOrderId, Quantity = 1 });
            builder.Entity<Location>().HasData(new Location() { ID = locationGuid, x = 11, y = 11, z = 11 });
            builder.Entity<Location>().HasData(new Location() { ID = locationGuid_2, x = 11, y = 22, z = 11 });
            builder.Entity<Container>().HasData(new Container() { ID = containerGuid, LocationId = locationGuid, Label = "Container-X" });
            builder.Entity<Container>().HasData(new Container() { ID = containerGuid_2, LocationId = locationGuid_2, Label = "Container-Y" });
            builder.Entity<InventoryItem>().HasData(new InventoryItem() { ID = inventoryGuid, ContainerId = containerGuid, Type = Domain.Enum.InventoryItemType.Reserved, ProductId = productID, LineItemId = lineItemId });
            builder.Entity<InventoryItem>().HasData(new InventoryItem() { ID = inventoryGuid_2, ContainerId = containerGuid, Type = Domain.Enum.InventoryItemType.Stock, ProductId = productID });
            builder.Entity<InventoryItem>().HasData(new InventoryItem() { ID = inventoryGuid_3, ContainerId = containerGuid_2, Type = Domain.Enum.InventoryItemType.Stock, ProductId = productID });
            builder.Entity<InventoryItem>().HasData(new InventoryItem() { ID = inventoryGuid_4, ContainerId = containerGuid_2, Type = Domain.Enum.InventoryItemType.Stock, ProductId = productID_2 });
            builder.Entity<InventoryItem>().HasData(new InventoryItem() { ID = inventoryGuid_5, ContainerId = containerGuid_2, Type = Domain.Enum.InventoryItemType.Stock, ProductId = productID_2 });
            builder.Entity<ApiUser>().HasData(new ApiUser() { ID = apiuserId, Username = "seller", Password = "seller", Role = Domain.Enum.ApiUserRole.Seller });
            builder.Entity<ApiUser>().HasData(new ApiUser() { ID = apiuserId_2, Username = "operator", Password = "operator", Role = Domain.Enum.ApiUserRole.Operator });
        }
    }
}
