using Pokeee.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Pokeee.Trainers
{
    public interface ITrainersAppService : IApplicationService
    {
        Task<PagedResultDto<TrainerWithNavigationPropertiesDto>> GetListAsync(GetTrainersInput input);

        Task<TrainerWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<TrainerDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPokemonLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<TrainerDto> CreateAsync(TrainerCreateDto input);

        Task<TrainerDto> UpdateAsync(Guid id, TrainerUpdateDto input);
    }
}