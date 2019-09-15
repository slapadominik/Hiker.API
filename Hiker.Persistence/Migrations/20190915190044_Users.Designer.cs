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
    [Migration("20190915190044_Users")]
    partial class Users
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

                    b.Property<Guid>("ThumbnailId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Mountains");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.MountainImage", b =>
                {
                    b.Property<Guid>("ImageId");

                    b.Property<int>("MountainId");

                    b.HasKey("ImageId", "MountainId");

                    b.HasIndex("MountainId");

                    b.ToTable("MountainImages");
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

                    b.Property<Guid?>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<int>("DurationDays");

                    b.Property<int>("MaxParticipants");

                    b.Property<string>("TripTitle");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

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

            modelBuilder.Entity("Hiker.Persistence.DAO.TripParticipant", b =>
                {
                    b.Property<int>("TripId");

                    b.Property<Guid>("UserId");

                    b.HasKey("TripId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TripParticipants");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email");

                    b.Property<string>("FacebookId");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.Mountain", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.MountainImage", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.Mountain", "Mountain")
                        .WithMany("MountainImages")
                        .HasForeignKey("MountainId")
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

            modelBuilder.Entity("Hiker.Persistence.DAO.Trip", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.User", "Author")
                        .WithMany("CreatedTrips")
                        .HasForeignKey("AuthorId");
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

            modelBuilder.Entity("Hiker.Persistence.DAO.TripParticipant", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.Trip", "Trip")
                        .WithMany("TripParticipants")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hiker.Persistence.DAO.User", "User")
                        .WithMany("TripParticipants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
