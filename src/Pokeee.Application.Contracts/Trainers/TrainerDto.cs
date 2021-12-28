using System;
using Volo.Abp.Application.Dtos;

namespace Pokeee.Trainers
{
    public class TrainerDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid PokemonId { get; set; }
    }
}