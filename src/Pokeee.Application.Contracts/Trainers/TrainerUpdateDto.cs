using System;
using System.ComponentModel.DataAnnotations;

namespace Pokeee.Trainers
{
    public class TrainerUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public Guid PokemonId { get; set; }
    }
}