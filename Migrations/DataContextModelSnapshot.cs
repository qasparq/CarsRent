// <auto-generated />
using CarsRent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarsRent.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<int>("CarAvaible")
                        .HasColumnType("int");

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<float>("Combustion")
                        .HasColumnType("real");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasePrice = 90,
                            CarAvaible = 3,
                            CarType = 13,
                            Combustion = 9f,
                            Localization = "Rzeszów",
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 2,
                            BasePrice = 100,
                            CarAvaible = 9,
                            CarType = 20,
                            Combustion = 12f,
                            Localization = "Warszawa",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 3,
                            BasePrice = 250,
                            CarAvaible = 1,
                            CarType = 10,
                            Combustion = 5f,
                            Localization = "Tarnów",
                            Name = "Chevrolet"
                        },
                        new
                        {
                            Id = 4,
                            BasePrice = 10,
                            CarAvaible = 1,
                            CarType = 16,
                            Combustion = 21f,
                            Localization = "Kraków",
                            Name = "Polonez"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
