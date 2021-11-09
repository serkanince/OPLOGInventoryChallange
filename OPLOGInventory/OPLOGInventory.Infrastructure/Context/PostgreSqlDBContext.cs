using Microsoft.EntityFrameworkCore;
using OPLOGInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Infrastructure.DB
{
    public sealed class PostgreSqlDBContext : DbContext
    {
        public PostgreSqlDBContext(DbContextOptions<PostgreSqlDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SalesOrder>().HasIndex(b => b.ReferanceNo);
            builder.Entity<Product>().HasIndex(b => b.SKU);
            builder.Entity<Container>().HasIndex(b => b.Label);

            builder.Seed();
        }


        public DbSet<Container> Container { get; set; }
        public DbSet<Dimension> Dimension { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Barcode> Barcode { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }

        public DbSet<ApiUser> ApiUser { get; set; }

    }
}
