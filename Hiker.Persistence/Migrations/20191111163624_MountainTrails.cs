using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiker.Persistence.Migrations
{
    public partial class MountainTrails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageTimeMinutes",
                table: "MountainTrails");

            migrationBuilder.RenameColumn(
                name: "Difficulty",
                table: "MountainTrails",
                newName: "TimeToTopMinutes");

            migrationBuilder.AlterColumn<string>(
                name: "ColorName",
                table: "MountainTrailColors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "FileExtensions",
                table: "MountainImages",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MountainTrailColors",
                columns: new[] { "Id", "ColorName" },
                values: new object[,]
                {
                    { 1, "red" },
                    { 2, "blue" },
                    { 3, "yellow" },
                    { 4, "black" },
                    { 5, "green" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MountainTrailColors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MountainTrailColors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MountainTrailColors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MountainTrailColors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MountainTrailColors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "FileExtensions",
                table: "MountainImages");

            migrationBuilder.RenameColumn(
                name: "TimeToTopMinutes",
                table: "MountainTrails",
                newName: "Difficulty");

            migrationBuilder.AddColumn<int>(
                name: "AverageTimeMinutes",
                table: "MountainTrails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ColorName",
                table: "MountainTrailColors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
