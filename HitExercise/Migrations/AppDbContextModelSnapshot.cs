﻿// <auto-generated />
using HitExercise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HitExercise.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HitExercise.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Food-Supply"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Room-Equipment"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Electronic-Equipment"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Medical-Equipment"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Garden-Equipment"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Pool-Equipment"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "FireSecurity-Equipment"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "Plumber-Equipment"
                        });
                });

            modelBuilder.Entity("HitExercise.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "Argentina"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Bangladesh"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "Belgium"
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "China"
                        },
                        new
                        {
                            CountryId = 5,
                            Name = "Chile"
                        },
                        new
                        {
                            CountryId = 6,
                            Name = "Denmark"
                        },
                        new
                        {
                            CountryId = 7,
                            Name = "Egypt"
                        },
                        new
                        {
                            CountryId = 8,
                            Name = "France"
                        },
                        new
                        {
                            CountryId = 9,
                            Name = "Germany"
                        },
                        new
                        {
                            CountryId = 10,
                            Name = "Greece"
                        },
                        new
                        {
                            CountryId = 11,
                            Name = "India"
                        },
                        new
                        {
                            CountryId = 12,
                            Name = "Italy"
                        },
                        new
                        {
                            CountryId = 13,
                            Name = "Japan"
                        },
                        new
                        {
                            CountryId = 14,
                            Name = "Malaysia"
                        },
                        new
                        {
                            CountryId = 15,
                            Name = "Morroco"
                        },
                        new
                        {
                            CountryId = 16,
                            Name = "Netherlands"
                        },
                        new
                        {
                            CountryId = 17,
                            Name = "Pakistan"
                        },
                        new
                        {
                            CountryId = 18,
                            Name = "Portugal"
                        },
                        new
                        {
                            CountryId = 19,
                            Name = "Russia"
                        },
                        new
                        {
                            CountryId = 20,
                            Name = "Spain"
                        },
                        new
                        {
                            CountryId = 21,
                            Name = "Sweeden"
                        },
                        new
                        {
                            CountryId = 22,
                            Name = "Turkey"
                        },
                        new
                        {
                            CountryId = 23,
                            Name = "USA"
                        },
                        new
                        {
                            CountryId = 24,
                            Name = "United Kingdom"
                        },
                        new
                        {
                            CountryId = 25,
                            Name = "Venezuela"
                        });
                });

            modelBuilder.Entity("HitExercise.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Afm")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("SupplierId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("HitExercise.Models.Supplier", b =>
                {
                    b.HasOne("HitExercise.Models.Category", "Category")
                        .WithMany("Suppliers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HitExercise.Models.Country", "Country")
                        .WithMany("Suppliers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HitExercise.Models.Category", b =>
                {
                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("HitExercise.Models.Country", b =>
                {
                    b.Navigation("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
