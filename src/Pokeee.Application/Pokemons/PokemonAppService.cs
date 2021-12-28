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
using Pokeee.Pokemons;

namespace Pokeee.Pokemons
{

    [Authorize(PokeeePermissions.Pokemons.Default)]
    public class PokemonsAppService : ApplicationService, IPokemonsAppService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonsAppService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public virtual async Task<PagedResultDto<PokemonDto>> GetListAsync(GetPokemonsInput input)
        {
            var totalCount = await _pokemonRepository.GetCountAsync(input.FilterText, input.Avatar, input.Name, input.SlotMin, input.SlotMax, input.Type);
            var items = await _pokemonRepository.GetListAsync(input.FilterText, input.Avatar, input.Name, input.SlotMin, input.SlotMax, input.Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PokemonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Pokemon>, List<PokemonDto>>(items)
            };
        }

        public virtual async Task<PokemonDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Pokemon, PokemonDto>(await _pokemonRepository.GetAsync(id));
        }

        [Authorize(PokeeePermissions.Pokemons.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _pokemonRepository.DeleteAsync(id);
        }

        [Authorize(PokeeePermissions.Pokemons.Create)]
        public virtual async Task<PokemonDto> CreateAsync(PokemonCreateDto input)
        {

            var pokemon = ObjectMapper.Map<PokemonCreateDto, Pokemon>(input);

            pokemon = await _pokemonRepository.InsertAsync(pokemon, autoSave: true);
            return ObjectMapper.Map<Pokemon, PokemonDto>(pokemon);
        }

        [Authorize(PokeeePermissions.Pokemons.Edit)]
        public virtual async Task<PokemonDto> UpdateAsync(Guid id, PokemonUpdateDto input)
        {

            var pokemon = await _pokemonRepository.GetAsync(id);
            ObjectMapper.Map(input, pokemon);
            pokemon = await _pokemonRepository.UpdateAsync(pokemon, autoSave: true);
            return ObjectMapper.Map<Pokemon, PokemonDto>(pokemon);
        }
    }
}