using Pokeee.Pokemons;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Pokeee.Trainers
{
    public class Trainer : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }
        public Guid PokemonId { get; set; }

        public Trainer()
        {

        }

        public Trainer(Guid id, string name, Guid pokemonId)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Name = name;
            PokemonId = pokemonId;
        }
    }
}