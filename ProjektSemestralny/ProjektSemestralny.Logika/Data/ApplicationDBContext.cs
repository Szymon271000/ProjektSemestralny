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
                new Category { Id = 12, Name = "Monitors"},
                new Category { Id = 13, Name = "Smartwatches"},
                new Category { Id = 14, Name = "Soundbars"},
                new Category { Id = 15, Name = "Projectors" },
                new Category { Id = 16, Name = "Powerbanks"},
                new Category { Id = 17, Name = "Printers" },
                new Category { Id = 18, Name = "Consoles"},
                new Category { Id = 19, Name = "Refrigerators" },
                new Category { Id = 20, Name = "Washing machines" },
                new Category { Id = 21, Name = "Ovens" }
                );

            modelBuilder.Entity<Producent>().HasData(
                new Producent { Id = 50, Name = "Samsung" },
                new Producent { Id = 51, Name = "Motorola" },
                new Producent { Id = 52, Name = "Panasonic" },
                new Producent { Id = 53, Name = "Electrolux"},
                new Producent { Id = 54, Name = "Sony"},
                new Producent { Id = 55, Name = "HP"},
                new Producent { Id = 56, Name = "Huawei"},
                new Producent { Id = 57, Name = "Boose"},
                new Producent { Id = 58, Name = "Sbs"},
                new Producent { Id = 59, Name = "Epson"}
                );

            modelBuilder.Entity<CategoryProducent>().HasData(
                new CategoryProducent { Id = 1, CategoryId = 10, ProducentId = 50 },
                new CategoryProducent { Id = 2, CategoryId = 11, ProducentId = 51 },
                new CategoryProducent { Id = 3, CategoryId = 12, ProducentId = 52 },
                new CategoryProducent { Id = 4, CategoryId = 13, ProducentId = 50},
                new CategoryProducent { Id = 5, CategoryId = 14, ProducentId = 57},
                new CategoryProducent { Id = 6, CategoryId = 15, ProducentId = 59},
                new CategoryProducent { Id = 7, CategoryId = 16, ProducentId = 58},
                new CategoryProducent { Id = 8, CategoryId = 17, ProducentId = 59},
                new CategoryProducent { Id = 9, CategoryId = 18, ProducentId = 54},
                new CategoryProducent { Id = 10, CategoryId = 19, ProducentId = 50},
                new CategoryProducent { Id = 11, CategoryId = 20, ProducentId = 53},
                new CategoryProducent { Id = 12, CategoryId = 21, ProducentId = 53}

                );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Galaxy S22 Ultra", Description = "Samsung's fastest, most powerful chip ever. That means, a faster CPU and GPU compared to Galaxy S21 Ultra. It’s an epic leap for smartphone technology.", Price = 1199.00, CategoryProducentId = 1 },
                new Item { Id = 2, Name = "ATRIX 4G", Description = "Laptop dock for the Motorola ATRIX 4G for a more interactive computer-like experience from your smartphone", Price = 500, CategoryProducentId= 2 },
                new Item { Id = 3, Name = "TH-75CQ2U 75 4K UHD Professional TV", Description = "6 Models of Entry-level Displays with 4K High-Definition Image Quality.", Price = 600, CategoryProducentId = 3 },
                new Item { Id = 4, Name = "Smartwatch SAMSUNG Galaxy Watch 4", Description = "Galaxy Watch4 Classic runs faster (compared to Galaxy Watch3), efficiently activates applications that you have even more space to do.", Price = 1199.00, CategoryProducentId = 4 },
                new Item { Id = 5, Name = "Soundbar BOSE Smart Soundbar 900", Description = "Bose Voice4Video's unique technology extends voice control through Alex's assistant, something no other soundbar can do.", Price = 4699.00, CategoryProducentId = 5 },
                new Item { Id = 6, Name = "Projektor EPSON EH-TW740", Description = "Enjoy your favorite movies with this Full HD projector.", Price = 2699.00, CategoryProducentId = 6 },
                new Item { Id = 7, Name = "Powerbank SBS 20000mAh Czarny TTBB20000FASTK", Description = "With a high capacity battery, you don't have to worry about running out of battery power on your device.", Price = 119.00, CategoryProducentId = 7 },
                new Item { Id = 8, Name = "EPSON EcoTank L3251", Description = "Save up to 90% on printing costs with this Epson EcoTank L3251 printer.", Price = 869.00, CategoryProducentId = 8 },
                new Item { Id = 9, Name = "PlayStation 5 B Chassis", Description = "The PS5 takes gaming to a new level you don't even expect.", Price = 2799.00, CategoryProducentId = 9 },
                new Item { Id = 10, Name = "PlayStation 5 B Chassis", Description = "The PS5 takes gaming to a new level you don't even expect.", Price = 2799.00, CategoryProducentId = 10 },
                new Item { Id = 11, Name = "SAMSUNG Bespoke RB38A6B2E22/EF", Description = "Looking for a unique refrigerator that fits perfectly into your kitchen style? If you're looking at design, the BESPOKE range of refrigerators will allow you to choose from a range of colors and textures.", Price = 2949.00, CategoryProducentId = 11 },
                new Item { Id = 12, Name = "ELECTROLUX EOC8H31Z", Description = "The combination of steam and hot air ensures that the dishes do not dry and can be cooked at a lower temperature.", Price = 2799.00, CategoryProducentId = 12 }
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
