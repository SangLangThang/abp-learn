using Pokeee.Shared;
using Pokeee.Pokemons;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Pokeee.Permissions;
using Pokeee.Trainers;

namespace Pokeee.Trainers
{

    [Authorize(PokeeePermissions.Trainers.Default)]
    public class TrainersAppService : ApplicationService, ITrainersAppService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IRepository<Pokemon, Guid> _pokemonRepository;

        public TrainersAppService(ITrainerRepository trainerRepository, IRepository<Pokemon, Guid> pokemonRepository)
        {
            _trainerRepository = trainerRepository; _pokemonRepository = pokemonRepository;
        }

        public virtual async Task<PagedResultDto<TrainerWithNavigationPropertiesDto>> GetListAsync(GetTrainersInput input)
        {
            var totalCount = await _trainerRepository.GetCountAsync(input.FilterText, input.Name, input.PokemonId);
            var items = await _trainerRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Name, input.PokemonId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TrainerWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TrainerWithNavigationProperties>, List<TrainerWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<TrainerWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<TrainerWithNavigationProperties, TrainerWithNavigationPropertiesDto>
                (await _trainerRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<TrainerDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Trainer, TrainerDto>(await _trainerRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetPokemonLookupAsync(LookupRequestDto input)
        {
            var query = (await _pokemonRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Avatar != null &&
                         x.Avatar.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Pokemon>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Pokemon>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(PokeeePermissions.Trainers.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _trainerRepository.DeleteAsync(id);
        }

        [Authorize(PokeeePermissions.Trainers.Create)]
        public virtual async Task<TrainerDto> CreateAsync(TrainerCreateDto input)
        {
            if (input.PokemonId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Pokemon"]]);
            }

            var trainer = ObjectMapper.Map<TrainerCreateDto, Trainer>(input);

            trainer = await _trainerRepository.InsertAsync(trainer, autoSave: true);
            return ObjectMapper.Map<Trainer, TrainerDto>(trainer);
        }

        [Authorize(PokeeePermissions.Trainers.Edit)]
        public virtual async Task<TrainerDto> UpdateAsync(Guid id, TrainerUpdateDto input)
        {
            if (input.PokemonId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Pokemon"]]);
            }

            var trainer = await _trainerRepository.GetAsync(id);
            ObjectMapper.Map(input, trainer);
            trainer = await _trainerRepository.UpdateAsync(trainer, autoSave: true);
            return ObjectMapper.Map<Trainer, TrainerDto>(trainer);
        }
    }
}