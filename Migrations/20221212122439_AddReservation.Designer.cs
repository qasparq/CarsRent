﻿// <auto-generated />
using CarsRent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarsRent.Migrations
{
    [DbContext(typeof(CarsRentDbContext))]
    [Migration("20221212122439_AddReservation")]
    partial class AddReservation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarsRent.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarAvaible")
                        .HasColumnType("int");

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<float>("Combustion")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentalPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RentalPlaceId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarAvaible = 3,
                            CarType = 13,
                            Combustion = 9f,
                            Name = "Audi",
                            RentalPlaceId = 1
                        },
                        new
                        {
                            Id = 2,
                            CarAvaible = 9,
                            CarType = 20,
                            Combustion = 12f,
                            Name = "BMW",
                            RentalPlaceId = 3
                        },
                        new
                        {
                            Id = 3,
                            CarAvaible = 1,
                            CarType = 10,
                            Combustion = 5f,
                            Name = "Chevrolet",
                            RentalPlaceId = 2
                        },
                        new
                        {
                            Id = 4,
                            CarAvaible = 1,
                            CarType = 16,
                            Combustion = 21f,
                            Name = "Polonez",
                            RentalPlaceId = 1
                        });
                });

            modelBuilder.Entity("CarsRent.Entities.RentalPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RentalPlaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasePrice = 70,
                            City = "Krakow"
                        },
                        new
                        {
                            Id = 2,
                            BasePrice = 120,
                            City = "Rzeszow"
                        },
                        new
                        {
                            Id = 3,
                            BasePrice = 100,
                            City = "Warszawa"
                        });
                });

            modelBuilder.Entity("CarsRent.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CarsRent.Entities.Car", b =>
                {
                    b.HasOne("CarsRent.Entities.RentalPlace", null)
                        .WithMany("Car")
                        .HasForeignKey("RentalPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarsRent.Entities.Reservation", b =>
                {
                    b.HasOne("CarsRent.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarsRent.Entities.RentalPlace", b =>
                {
                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
