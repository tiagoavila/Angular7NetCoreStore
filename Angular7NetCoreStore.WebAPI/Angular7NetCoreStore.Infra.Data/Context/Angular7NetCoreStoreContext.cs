﻿using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Angular7NetCoreStore.Infra.Data.Context
{
    public class Angular7NetCoreStoreContext : DbContext
    {
        public Angular7NetCoreStoreContext(DbContextOptions<Angular7NetCoreStoreContext> options) : base(options)
        {

        }

        public Angular7NetCoreStoreContext()
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
