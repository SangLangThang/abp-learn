using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Pokeee.Pokemons
{
    public interface IPokemonsAppService : IApplicationService
    {
        Task<PagedResultDto<PokemonDto>> GetListAsync(GetPokemonsInput input);

        Task<PokemonDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<PokemonDto> CreateAsync(PokemonCreateDto input);

        Task<PokemonDto> UpdateAsync(Guid id, PokemonUpdateDto input);
    }
}