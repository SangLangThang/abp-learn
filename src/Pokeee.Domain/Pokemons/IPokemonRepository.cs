using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Pokeee.Pokemons
{
    public interface IPokemonRepository : IRepository<Pokemon, Guid>
    {
        Task<List<Pokemon>> GetListAsync(
            string filterText = null,
            string avatar = null,
            string name = null,
            int? slotMin = null,
            int? slotMax = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string avatar = null,
            string name = null,
            int? slotMin = null,
            int? slotMax = null,
            string type = null,
            CancellationToken cancellationToken = default);
    }
}