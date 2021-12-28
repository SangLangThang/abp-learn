using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokeee.Migrations
{
    public partial class Updated_Trainer_21121714163698 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PokemonId",
                table: "AppTrainers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppTrainers_PokemonId",
                table: "AppTrainers",
                column: "PokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTrainers_AppPokemons_PokemonId",
                table: "AppTrainers",
                column: "PokemonId",
                principalTable: "AppPokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTrainers_AppPokemons_PokemonId",
                table: "AppTrainers");

            migrationBuilder.DropIndex(
                name: "IX_AppTrainers_PokemonId",
                table: "AppTrainers");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "AppTrainers");
        }
    }
}
