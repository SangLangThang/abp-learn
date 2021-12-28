using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Pokeee.Pokemons;

namespace Pokeee.Pokemons
{
    public class PokemonsDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonsDataSeedContributor(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _pokemonRepository.InsertAsync(new Pokemon
            (
                id: Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3"),
                avatar: "b89b4abfa7814b9c834b6ed33a1e1703d90201d9ff894749aa",
                name: "04574998e3e54e95905149767263a79b3f66561e21ef46bbb57152b2ab3",
                slot: 736405158,
                type: "666f116539834bcdb3f6"
            ));

            await _pokemonRepository.InsertAsync(new Pokemon
            (
                id: Guid.Parse("a2362411-5ac5-48f9-8c1e-9e724c93298f"),
                avatar: "ebf4f4bf78da4",
                name: "069b7dccf76",
                slot: 1047627688,
                type: "c3eff5019a2344c1819488599d9cf54956fa5e41"
            ));
        }
    }
}