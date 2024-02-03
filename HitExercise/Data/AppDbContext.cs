using HitExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace HitExercise.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Suppliers)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.Country)
                .WithMany(c => c.Suppliers)
                .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Food-Supply", CategoryCode = 110 },
                new Category { CategoryId = 2, Name = "Room-Equipment", CategoryCode = 120 },
                new Category { CategoryId = 3, Name = "Electronic-Equipment", CategoryCode = 130 },
                new Category { CategoryId = 4, Name = "Medical-Equipment", CategoryCode = 140 },
                new Category { CategoryId = 5, Name = "Garden-Equipment", CategoryCode = 150 },
                new Category { CategoryId = 6, Name = "Pool-Equipment", CategoryCode = 160 },
                new Category { CategoryId = 7, Name = "FireSecurity-Equipment", CategoryCode = 170 },
                new Category { CategoryId = 8, Name = "Plumber-Equipment", CategoryCode = 180 }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "Argentina", CountryCode = 1210 },
                new Country { CountryId = 2, Name = "Bangladesh", CountryCode = 1220 },
                new Country { CountryId = 3, Name = "Belgium", CountryCode = 1230 },
                new Country { CountryId = 4, Name = "China", CountryCode = 1240 },
                new Country { CountryId = 5, Name = "Chile", CountryCode = 1250 },
                new Country { CountryId = 6, Name = "Denmark", CountryCode = 1260 },
                new Country { CountryId = 7, Name = "Egypt", CountryCode = 1270 },
                new Country { CountryId = 8, Name = "France", CountryCode = 1280 },
                new Country { CountryId = 9, Name = "Germany", CountryCode = 1290 },
                new Country { CountryId = 10, Name = "Greece", CountryCode = 1300 },
                new Country { CountryId = 11, Name = "India", CountryCode = 1310 },
                new Country { CountryId = 12, Name = "Italy", CountryCode = 1320 },
                new Country { CountryId = 13, Name = "Japan", CountryCode = 1330 },
                new Country { CountryId = 14, Name = "Malaysia", CountryCode = 1340 },
                new Country { CountryId = 15, Name = "Morroco", CountryCode = 1350 },
                new Country { CountryId = 16, Name = "Netherlands", CountryCode = 1360 },
                new Country { CountryId = 17, Name = "Pakistan", CountryCode = 1370 },
                new Country { CountryId = 18, Name = "Portugal", CountryCode = 1380 },
                new Country { CountryId = 19, Name = "Russia", CountryCode = 1390 },
                new Country { CountryId = 20, Name = "Spain", CountryCode = 1400 },
                new Country { CountryId = 21, Name = "Sweeden", CountryCode = 1410 },
                new Country { CountryId = 22, Name = "Turkey", CountryCode = 1420 },
                new Country { CountryId = 23, Name = "USA", CountryCode = 1430 },
                new Country { CountryId = 24, Name = "United Kingdom", CountryCode = 1440 },
                new Country { CountryId = 25, Name = "Venezuela", CountryCode = 1450 }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
