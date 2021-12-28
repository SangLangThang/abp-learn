using System;
using Volo.Abp.Application.Dtos;

namespace Pokeee.Pokemons
{
    public class PokemonDto : FullAuditedEntityDto<Guid>
    {
        public string Avatar { get; set; }
        public string Name { get; set; }
        public int Slot { get; set; }
        public string Type { get; set; }
    }
}