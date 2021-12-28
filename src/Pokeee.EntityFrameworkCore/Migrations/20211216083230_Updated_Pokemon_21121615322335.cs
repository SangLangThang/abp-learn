using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokeee.Migrations
{
    public partial class Updated_Pokemon_21121615322335 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppPokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Slot",
                table: "AppPokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppPokemons");

            migrationBuilder.DropColumn(
                name: "Slot",
                table: "AppPokemons");
        }
    }
}
