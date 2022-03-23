using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Refugee.Migrations
{
    public partial class RenamedColumnsUUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UUID",
                table: "Locations",
                newName: "uuid");

            migrationBuilder.RenameColumn(
                name: "UUID",
                table: "Drivers",
                newName: "uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "uuid",
                table: "Locations",
                newName: "UUID");

            migrationBuilder.RenameColumn(
                name: "uuid",
                table: "Drivers",
                newName: "UUID");
        }
    }
}
