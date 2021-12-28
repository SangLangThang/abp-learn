using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokeee.Migrations
{
    public partial class Updated_Pokemon_21121615400136 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AppPokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AppPokemons");
        }
    }
}
