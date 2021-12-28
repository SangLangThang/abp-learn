using Pokeee.Pokemons;

using System;
using Volo.Abp.Application.Dtos;

namespace Pokeee.Trainers
{
    public class TrainerWithNavigationPropertiesDto
    {
        public TrainerDto Trainer { get; set; }

        public PokemonDto Pokemon { get; set; }

    }
}