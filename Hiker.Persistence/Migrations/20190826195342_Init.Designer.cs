﻿// <auto-generated />
using System;
using Hiker.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hiker.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190826195342_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hiker.Persistence.DAO.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("RegionName");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.Mountain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId");

                    b.Property<int>("MetersAboveSeaLevel");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Mountains");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.MountainTrail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AverageTimeMinutes");

                    b.Property<int>("ColorId");

                    b.Property<int>("Difficulty");

                    b.Property<int?>("MountainId");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("MountainId");

                    b.ToTable("MountainTrails");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.MountainTrailColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorName");

                    b.HasKey("Id");

                    b.ToTable("MountainTrailColors");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DurationDays");

                    b.Property<int>("MaxParticipants");

                    b.Property<string>("TripTitle");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.TripDestination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomLocationId");

                    b.Property<int?>("MountainId");

                    b.Property<int>("TripDestinationTypeId");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("CustomLocationId");

                    b.HasIndex("MountainId");

                    b.HasIndex("TripDestinationTypeId");

                    b.HasIndex("TripId");

                    b.ToTable("TripDestinations");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.TripDestinationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TripDestinationTypes");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.Mountain", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.MountainTrail", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.MountainTrailColor", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hiker.Persistence.DAO.Mountain")
                        .WithMany("MountainTrail")
                        .HasForeignKey("MountainId");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.TripDestination", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.Location", "CustomLocation")
                        .WithMany()
                        .HasForeignKey("CustomLocationId");

                    b.HasOne("Hiker.Persistence.DAO.Mountain", "Mountain")
                        .WithMany()
                        .HasForeignKey("MountainId");

                    b.HasOne("Hiker.Persistence.DAO.TripDestinationType", "TripDestinationType")
                        .WithMany()
                        .HasForeignKey("TripDestinationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hiker.Persistence.DAO.Trip", "Trip")
                        .WithMany("TripDestinations")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
