using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Pokeee.Trainers;

namespace Pokeee.Trainers
{
    public class TrainersDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainersDataSeedContributor(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _trainerRepository.InsertAsync(new Trainer
            (
                id: Guid.Parse("4b22fe30-0ac2-4747-a3e8-e6bac350fbba"),
                name: "1fa7c96afd15414",
                pokemonId: Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3")
            ));

            await _trainerRepository.InsertAsync(new Trainer
            (
                id: Guid.Parse("703ec0f1-fe0f-4207-96bf-4339e7cb593e"),
                name: "b5a7c4d2",
                pokemonId: Guid.Parse("ebb20115-94c4-4702-8034-3000beb7e2b3")
            ));
        }
    }
}