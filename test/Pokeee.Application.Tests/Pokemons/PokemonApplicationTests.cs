using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Pokeee.Pokemons
{
    public class PokemonsAppServiceTests : PokeeeApplicationTestBase
    {
        private readonly IPokemonsAppService _pokemonsAppService;
        private readonly IRepository<Pokemon, Guid> _pokemonRepository;

        public PokemonsAppServiceTests()
        {
            _pokemonsAppService = GetRequiredService<IPokemonsAppService>();
            _pokemonRepository = GetRequiredService<IRepository<Pokemon, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _pokemonsAppService.GetListAsync(new GetPokemonsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("a2362411-5ac5-48f9-8c1e-9e724c93298f")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _pokemonsAppService.GetAsync(Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PokemonCreateDto
            {
                Avatar = "35df04c2152a4709b3e412262b92466ee886ed6f1dba422b9d0ecaf5",
                Name = "c37441c1de1e4f4",
                Slot = 793512358,
                Type = "12064198ffc7"
            };

            // Act
            var serviceResult = await _pokemonsAppService.CreateAsync(input);

            // Assert
            var result = await _pokemonRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Avatar.ShouldBe("35df04c2152a4709b3e412262b92466ee886ed6f1dba422b9d0ecaf5");
            result.Name.ShouldBe("c37441c1de1e4f4");
            result.Slot.ShouldBe(793512358);
            result.Type.ShouldBe("12064198ffc7");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PokemonUpdateDto()
            {
                Avatar = "9765bf2701a84208",
                Name = "7ceb1f17209246ea885f5723a2f95ff4e8e48f6a810d4f58a80c6ba6f26d0cded2b9ca5f",
                Slot = 965829560,
                Type = "2d0dbca61bfb4e0aa03e4897fabc1a4786eac86c40c74228a17f9bc31acc2fec374f57943ef741d1b4"
            };

            // Act
            var serviceResult = await _pokemonsAppService.UpdateAsync(Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3"), input);

            // Assert
            var result = await _pokemonRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Avatar.ShouldBe("9765bf2701a84208");
            result.Name.ShouldBe("7ceb1f17209246ea885f5723a2f95ff4e8e48f6a810d4f58a80c6ba6f26d0cded2b9ca5f");
            result.Slot.ShouldBe(965829560);
            result.Type.ShouldBe("2d0dbca61bfb4e0aa03e4897fabc1a4786eac86c40c74228a17f9bc31acc2fec374f57943ef741d1b4");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _pokemonsAppService.DeleteAsync(Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3"));

            // Assert
            var result = await _pokemonRepository.FindAsync(c => c.Id == Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3"));

            result.ShouldBeNull();
        }
    }
}