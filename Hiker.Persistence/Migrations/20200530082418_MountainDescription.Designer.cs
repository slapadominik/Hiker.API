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
    [Migration("20200530082418_MountainDescription")]
    partial class MountainDescription
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

                    b.Property<string>("RegionName");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.Mountain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<float>("Latitude");

                    b.Property<int>("LocationId");

                    b.Property<float>("Longitude");

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

                    b.Property<string>("FileExtensions");

                    b.HasKey("ImageId", "MountainId");

                    b.HasIndex("MountainId");

                    b.ToTable("MountainImages");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.MountainTrail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorId");

                    b.Property<int?>("MountainId");

                    b.Property<int>("TimeToTopMinutes");

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

                    b.Property<string>("ColorName");

                    b.HasKey("Id");

                    b.ToTable("MountainTrailColors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorName = "red"
                        },
                        new
                        {
                            Id = 2,
                            ColorName = "blue"
                        },
                        new
                        {
                            Id = 3,
                            ColorName = "yellow"
                        },
                        new
                        {
                            Id = 4,
                            ColorName = "black"
                        },
                        new
                        {
                            Id = 5,
                            ColorName = "green"
                        });
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.Rock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Rock");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("AuthorId");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime?>("DateTo");

                    b.Property<string>("Description");

                    b.Property<bool>("IsOneDay");

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

                    b.Property<int?>("MountainId");

                    b.Property<int?>("RockId");

                    b.Property<int>("TripDestinationTypeId");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("MountainId");

                    b.HasIndex("RockId");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mountain"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rock"
                        });
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

                    b.Property<string>("AboutMe");

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("Email");

                    b.Property<string>("FacebookId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

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

            modelBuilder.Entity("Hiker.Persistence.DAO.Rock", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.Trip", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.User", "Author")
                        .WithMany("CreatedTrips")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("Hiker.Persistence.DAO.TripDestination", b =>
                {
                    b.HasOne("Hiker.Persistence.DAO.Mountain", "Mountain")
                        .WithMany("TripDestinations")
                        .HasForeignKey("MountainId");

                    b.HasOne("Hiker.Persistence.DAO.Rock", "Rock")
                        .WithMany()
                        .HasForeignKey("RockId");

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
