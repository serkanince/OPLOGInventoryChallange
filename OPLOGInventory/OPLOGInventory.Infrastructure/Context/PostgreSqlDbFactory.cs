using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OPLOGInventory.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Text;


namespace OPLOGInventory.Data.Context
{
    public class DbFactory : IDesignTimeDbContextFactory<PostgreSqlDBContext>
    {
        /// <summary>
        /// Creates a new db context.
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The db context</returns>
        public PostgreSqlDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PostgreSqlDBContext>();
            builder.UseNpgsql("Server=localhost;Port=5432;Database=oplog;User ID=postgres;Password=nova;");
            return new PostgreSqlDBContext(builder.Options);
        }
    }
}
