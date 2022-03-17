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
            modelBuilder.Entity<Producent>().HasData(
                    new Producent { Id=1, Name="Samsung"},
                    new Producent { Id=2, Name="Sony"},
                    new Producent { Id=3, Name="Toshiba"},
                    new Producent { Id=4, Name="Apple"}
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
