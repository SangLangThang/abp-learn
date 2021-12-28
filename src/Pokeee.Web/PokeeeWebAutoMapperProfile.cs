using Pokeee.Trainers;
using Pokeee.Pokemons;
using AutoMapper;

namespace Pokeee.Web
{
    public class PokeeeWebAutoMapperProfile : Profile
    {
        public PokeeeWebAutoMapperProfile()
        {
            //Define your object mappings here, for the Web project

            CreateMap<PokemonDto, PokemonUpdateDto>();

            CreateMap<TrainerDto, TrainerUpdateDto>();
        }
    }
}