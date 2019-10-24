using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiker.Persistence.Migrations
{
    public partial class TripUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDestinations_Locations_CustomLocationId",
                table: "TripDestinations");

            migrationBuilder.DropColumn(
                name: "DurationDays",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "CustomLocationId",
                table: "TripDestinations",
                newName: "RockId");

            migrationBuilder.RenameIndex(
                name: "IX_TripDestinations_CustomLocationId",
                table: "TripDestinations",
                newName: "IX_TripDestinations_RockId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Trips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Trips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Rock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rock_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TripDestinationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mountain" });

            migrationBuilder.InsertData(
                table: "TripDestinationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Rock" });

            migrationBuilder.CreateIndex(
                name: "IX_Rock_LocationId",
                table: "Rock",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDestinations_Rock_RockId",
                table: "TripDestinations",
                column: "RockId",
                principalTable: "Rock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDestinations_Rock_RockId",
                table: "TripDestinations");

            migrationBuilder.DropTable(
                name: "Rock");

            migrationBuilder.DeleteData(
                table: "TripDestinationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TripDestinationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "RockId",
                table: "TripDestinations",
                newName: "CustomLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_TripDestinations_RockId",
                table: "TripDestinations",
                newName: "IX_TripDestinations_CustomLocationId");

            migrationBuilder.AddColumn<int>(
                name: "DurationDays",
                table: "Trips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "Trips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDestinations_Locations_CustomLocationId",
                table: "TripDestinations",
                column: "CustomLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
