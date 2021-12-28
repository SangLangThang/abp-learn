using Pokeee.Trainers;
using System;
using Pokeee.Shared;
using Volo.Abp.AutoMapper;
using Pokeee.Pokemons;
using AutoMapper;

namespace Pokeee
{
    public class PokeeeApplicationAutoMapperProfile : Profile
    {
        public PokeeeApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<PokemonCreateDto, Pokemon>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<PokemonUpdateDto, Pokemon>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Pokemon, PokemonDto>();

            CreateMap<TrainerCreateDto, Trainer>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<TrainerUpdateDto, Trainer>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Trainer, TrainerDto>();

            CreateMap<TrainerWithNavigationProperties, TrainerWithNavigationPropertiesDto>();
            CreateMap<Pokemon, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

            CreateMap<Pokemon, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Avatar));
        }
    }
}