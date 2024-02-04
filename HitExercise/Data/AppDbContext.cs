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
                new Category { CategoryId = 1, Name = "Food-Supply" },
                new Category { CategoryId = 2, Name = "Room-Equipment" },
                new Category { CategoryId = 3, Name = "Electronic-Equipment" },
                new Category { CategoryId = 4, Name = "Medical-Equipment" },
                new Category { CategoryId = 5, Name = "Garden-Equipment" },
                new Category { CategoryId = 6, Name = "Pool-Equipment" },
                new Category { CategoryId = 7, Name = "FireSecurity-Equipment" },
                new Category { CategoryId = 8, Name = "Plumber-Equipment" }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "Argentina" },
                new Country { CountryId = 2, Name = "Bangladesh" },
                new Country { CountryId = 3, Name = "Belgium" },
                new Country { CountryId = 4, Name = "China" },
                new Country { CountryId = 5, Name = "Chile" },
                new Country { CountryId = 6, Name = "Denmark" },
                new Country { CountryId = 7, Name = "Egypt" },
                new Country { CountryId = 8, Name = "France" },
                new Country { CountryId = 9, Name = "Germany" },
                new Country { CountryId = 10, Name = "Greece" },
                new Country { CountryId = 11, Name = "India" },
                new Country { CountryId = 12, Name = "Italy" },
                new Country { CountryId = 13, Name = "Japan" },
                new Country { CountryId = 14, Name = "Malaysia" },
                new Country { CountryId = 15, Name = "Morroco" },
                new Country { CountryId = 16, Name = "Netherlands" },
                new Country { CountryId = 17, Name = "Pakistan" },
                new Country { CountryId = 18, Name = "Portugal" },
                new Country { CountryId = 19, Name = "Russia" },
                new Country { CountryId = 20, Name = "Spain" },
                new Country { CountryId = 21, Name = "Sweeden" },
                new Country { CountryId = 22, Name = "Turkey" },
                new Country { CountryId = 23, Name = "USA" },
                new Country { CountryId = 24, Name = "United Kingdom" },
                new Country { CountryId = 25, Name = "Venezuela" }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
