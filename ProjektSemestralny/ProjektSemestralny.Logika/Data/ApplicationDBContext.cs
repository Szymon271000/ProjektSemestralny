using Microsoft.EntityFrameworkCore;
using ProjektSemestralny.Logika.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika.Data
{
    public class ApplicationDBContext: DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = Configuration.GetConfiguration("config.json");
            optionsBuilder.UseSqlServer(configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 10, Name = "Mobiles"},
                new Category { Id = 11, Name = "Laptops"},
                new Category { Id = 12, Name = "Monitors"}
                );

            modelBuilder.Entity<Producent>().HasData(
                new Producent { Id = 50, Name = "Samsung" },
                new Producent { Id = 51, Name = "Motorola" },
                new Producent { Id = 52, Name = "Panasonic" }
                );

            modelBuilder.Entity<CategoryProducent>().HasData(
                new CategoryProducent { Id = 1, CategoryId = 10, ProducentId = 50 },
                new CategoryProducent { Id = 2, CategoryId = 11, ProducentId = 51 },
                new CategoryProducent { Id = 3, CategoryId = 12, ProducentId = 52 }
                );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Galaxy S22 Ultra", Description = "Samsung's fastest, most powerful chip ever. That means, a faster CPU and GPU compared to Galaxy S21 Ultra. It’s an epic leap for smartphone technology.", Price = 1199.00, CategoryProducentId = 1 },
                new Item { Id = 2, Name = "ATRIX 4G", Description = "Laptop dock for the Motorola ATRIX 4G for a more interactive computer-like experience from your smartphone", Price = 500, CategoryProducentId= 2 },
                new Item { Id = 3, Name = "TH-75CQ2U 75 4K UHD Professional TV", Description = "6 Models of Entry-level Displays with 4K High-Definition Image Quality.", CategoryProducentId = 3 }
                );
                }

        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProducent> CategoryProducents { get; set; }
        
        public DbSet<Producent> Producents { get; set; }

    }
}
