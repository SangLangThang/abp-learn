using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Pokeee.Pokemons;
using Pokeee.EntityFrameworkCore;
using Xunit;

namespace Pokeee.Pokemons
{
    public class PokemonRepositoryTests : PokeeeEntityFrameworkCoreTestBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonRepositoryTests()
        {
            _pokemonRepository = GetRequiredService<IPokemonRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _pokemonRepository.GetListAsync(
                    avatar: "b89b4abfa7814b9c834b6ed33a1e1703d90201d9ff894749aa",
                    name: "04574998e3e54e95905149767263a79b3f66561e21ef46bbb57152b2ab3",
                    type: "666f116539834bcdb3f6"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _pokemonRepository.GetCountAsync(
                    avatar: "ebf4f4bf78da4",
                    name: "069b7dccf76",
                    type: "c3eff5019a2344c1819488599d9cf54956fa5e41"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}