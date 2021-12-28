using System;
using System.ComponentModel.DataAnnotations;

namespace Pokeee.Pokemons
{
    public class PokemonUpdateDto
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