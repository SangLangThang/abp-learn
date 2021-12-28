using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Pokeee.Trainers
{
    public class TrainersAppServiceTests : PokeeeApplicationTestBase
    {
        private readonly ITrainersAppService _trainersAppService;
        private readonly IRepository<Trainer, Guid> _trainerRepository;

        public TrainersAppServiceTests()
        {
            _trainersAppService = GetRequiredService<ITrainersAppService>();
            _trainerRepository = GetRequiredService<IRepository<Trainer, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _trainersAppService.GetListAsync(new GetTrainersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Trainer.Id == Guid.Parse("4b22fe30-0ac2-4747-a3e8-e6bac350fbba")).ShouldBe(true);
            result.Items.Any(x => x.Trainer.Id == Guid.Parse("703ec0f1-fe0f-4207-96bf-4339e7cb593e")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _trainersAppService.GetAsync(Guid.Parse("4b22fe30-0ac2-4747-a3e8-e6bac350fbba"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("4b22fe30-0ac2-4747-a3e8-e6bac350fbba"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TrainerCreateDto
            {
                Name = "94348825e5a54a3bb55cd28388c09",
                PokemonId = Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3")
            };

            // Act
            var serviceResult = await _trainersAppService.CreateAsync(input);

            // Assert
            var result = await _trainerRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("94348825e5a54a3bb55cd28388c09");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TrainerUpdateDto()
            {
                Name = "28ce3f5969714e589466f9a49c1686c49118b34dc24647a7945062308478a3ce448bf12fa6864ef98cbe3c7dc",
                PokemonId = Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3")
            };

            // Act
            var serviceResult = await _trainersAppService.UpdateAsync(Guid.Parse("4b22fe30-0ac2-4747-a3e8-e6bac350fbba"), input);

            // Assert
            var result = await _trainerRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("28ce3f5969714e589466f9a49c1686c49118b34dc24647a7945062308478a3ce448bf12fa6864ef98cbe3c7dc");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _trainersAppService.DeleteAsync(Guid.Parse("4b22fe30-0ac2-4747-a3e8-e6bac350fbba"));

            // Assert
            var result = await _trainerRepository.FindAsync(c => c.Id == Guid.Parse("4b22fe30-0ac2-4747-a3e8-e6bac350fbba"));

            result.ShouldBeNull();
        }
    }
}