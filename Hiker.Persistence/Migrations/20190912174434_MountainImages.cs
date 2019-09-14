using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiker.Persistence.Migrations
{
    public partial class MountainImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ThumbnailId",
                table: "Mountains",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MountainImages",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(nullable: false),
                    MountainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainImages", x => new { x.ImageId, x.MountainId });
                    table.ForeignKey(
                        name: "FK_MountainImages_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MountainImages_MountainId",
                table: "MountainImages",
                column: "MountainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MountainImages");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Mountains");
        }
    }
}
