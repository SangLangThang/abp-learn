using System;
using System.ComponentModel.DataAnnotations;

namespace Pokeee.Pokemons
{
    public class PokemonCreateDto
    {
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Slot { get; set; }
        [Required]
        public string Type { get; set; }
    }
}