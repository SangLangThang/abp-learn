using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Pokeee.EntityFrameworkCore;

namespace Pokeee.Pokemons
{
    public class EfCorePokemonRepository : EfCoreRepository<PokeeeDbContext, Pokemon, Guid>, IPokemonRepository
    {
        public EfCorePokemonRepository(IDbContextProvider<PokeeeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Pokemon>> GetListAsync(
            string filterText = null,
            string avatar = null,
            string name = null,
            int? slotMin = null,
            int? slotMax = null,
            string type = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, avatar, name, slotMin, slotMax, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PokemonConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string avatar = null,
            string name = null,
            int? slotMin = null,
            int? slotMax = null,
            string type = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, avatar, name, slotMin, slotMax, type);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Pokemon> ApplyFilter(
            IQueryable<Pokemon> query,
            string filterText,
            string avatar = null,
            string name = null,
            int? slotMin = null,
            int? slotMax = null,
            string type = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Avatar.Contains(filterText) || e.Name.Contains(filterText) || e.Type.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(avatar), e => e.Avatar.Contains(avatar))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(slotMin.HasValue, e => e.Slot >= slotMin.Value)
                    .WhereIf(slotMax.HasValue, e => e.Slot <= slotMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.Type.Contains(type));
        }
    }
}