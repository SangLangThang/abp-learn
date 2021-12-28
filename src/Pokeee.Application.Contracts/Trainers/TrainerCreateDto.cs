using System;
using System.ComponentModel.DataAnnotations;

namespace Pokeee.Trainers
{
    public class TrainerCreateDto
    {
        [Required]
        public string Name { get; set; }
        public Guid PokemonId { get; set; }
    }
}