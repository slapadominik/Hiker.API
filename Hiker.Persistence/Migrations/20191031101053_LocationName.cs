using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiker.Persistence.Migrations
{
    public partial class LocationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rock_Locations_LocationId",
                table: "Rock");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Rock",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rock",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rock_Locations_LocationId",
                table: "Rock",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rock_Locations_LocationId",
                table: "Rock");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rock");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Rock",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Rock_Locations_LocationId",
                table: "Rock",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
