namespace ProductManagement.Migrations
{
    using ProductManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductManagement.Models.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductManagement.Models.ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (!context.Categorys.Any(c => c.Name == "Accessories" && c.ID == 1))
            {
                context.Categorys.AddRange(new List<Category> {
                    new Category ("Accessories"),
                    new Category ("Desktop"),
                    new Category ("IP Phone"),
                    new Category ("Laptop"),
                    new Category ("Monitor"),
                    new Category ("Server"),
                    new Category ("SmartPhone")
                });
                context.SaveChanges();
            }

            if(!context.Products.Any(p => p.Name == "Airpods" && p.ID == 1))
            {
                context.Products.AddRange(new List<Product> {
                    new Product ("Airpods", "Headphone for me!", 1, 1),
                    new Product ("Lenovo", "Desktop for FIT!", 20, 2),
                    new Product ("Lenovo ThinkVision", "LCD Monitor!", 10, 5),
                    new Product ("HP Pavillion", "Laptop for boss!", 5, 4),
                    new Product ("IP Phone", "IP phone for internal connection!", 100, 3),
                    new Product ("TP-Link Server", "Server for company!", 2, 6),
                    new Product ("Samsung galaxy Note 10", "Smart phone for me!", 1, 7)
                });
                context.SaveChanges();
            }
            
        }
    }
}
