using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiker.Persistence.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Trips",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    FacebookId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripParticipants",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripParticipants", x => new { x.TripId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TripParticipants_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_AuthorId",
                table: "Trips",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TripParticipants_UserId",
                table: "TripParticipants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_AuthorId",
                table: "Trips",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_AuthorId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "TripParticipants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Trips_AuthorId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Trips");
        }
    }
}
