using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Pokeee.Pokemons
{
    public class Pokemon : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Avatar { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        public virtual int Slot { get; set; }

        [NotNull]
        public virtual string Type { get; set; }

        public Pokemon()
        {

        }

        public Pokemon(Guid id, string avatar, string name, int slot, string type)
        {
            Id = id;
            Check.NotNull(avatar, nameof(avatar));
            Check.NotNull(name, nameof(name));
            Check.NotNull(type, nameof(type));
            Avatar = avatar;
            Name = name;
            Slot = slot;
            Type = type;
        }
    }
}