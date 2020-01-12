using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    // Enable-Migrations
    // Add-Migration init
    // Update-Database
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public ProductContext() : base("ProductManagementDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}