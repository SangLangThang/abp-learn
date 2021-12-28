using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Pokeee.Trainers;
using Pokeee.EntityFrameworkCore;
using Xunit;

namespace Pokeee.Trainers
{
    public class TrainerRepositoryTests : PokeeeEntityFrameworkCoreTestBase
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerRepositoryTests()
        {
            _trainerRepository = GetRequiredService<ITrainerRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _trainerRepository.GetListAsync(
                    name: "1fa7c96afd15414"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("4b22fe30-0ac2-4747-a3e8-e6bac350fbba"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _trainerRepository.GetCountAsync(
                    name: "b5a7c4d2"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}