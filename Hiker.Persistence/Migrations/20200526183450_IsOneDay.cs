using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiker.Persistence.Migrations
{
    public partial class IsOneDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTo",
                table: "Trips",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "IsOneDay",
                table: "Trips",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOneDay",
                table: "Trips");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTo",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
