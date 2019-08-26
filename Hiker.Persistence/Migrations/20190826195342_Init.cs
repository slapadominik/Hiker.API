using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiker.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    RegionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MountainTrailColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainTrailColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripDestinationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDestinationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripTitle = table.Column<string>(nullable: true),
                    DurationDays = table.Column<int>(nullable: false),
                    MaxParticipants = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mountains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MetersAboveSeaLevel = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mountains_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MountainTrails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AverageTimeMinutes = table.Column<int>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    MountainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MountainTrails_MountainTrailColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "MountainTrailColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MountainTrails_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripDestinations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripId = table.Column<int>(nullable: false),
                    TripDestinationTypeId = table.Column<int>(nullable: false),
                    MountainId = table.Column<int>(nullable: true),
                    CustomLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDestinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDestinations_Locations_CustomLocationId",
                        column: x => x.CustomLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripDestinations_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripDestinations_TripDestinationTypes_TripDestinationTypeId",
                        column: x => x.TripDestinationTypeId,
                        principalTable: "TripDestinationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDestinations_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mountains_LocationId",
                table: "Mountains",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainTrails_ColorId",
                table: "MountainTrails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainTrails_MountainId",
                table: "MountainTrails",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDestinations_CustomLocationId",
                table: "TripDestinations",
                column: "CustomLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDestinations_MountainId",
                table: "TripDestinations",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDestinations_TripDestinationTypeId",
                table: "TripDestinations",
                column: "TripDestinationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDestinations_TripId",
                table: "TripDestinations",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MountainTrails");

            migrationBuilder.DropTable(
                name: "TripDestinations");

            migrationBuilder.DropTable(
                name: "MountainTrailColors");

            migrationBuilder.DropTable(
                name: "Mountains");

            migrationBuilder.DropTable(
                name: "TripDestinationTypes");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
