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

namespace Pokeee.Trainers
{
    public class EfCoreTrainerRepository : EfCoreRepository<PokeeeDbContext, Trainer, Guid>, ITrainerRepository
    {
        public EfCoreTrainerRepository(IDbContextProvider<PokeeeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<TrainerWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Trainer.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<TrainerWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string name = null,
            Guid? pokemonId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, pokemonId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TrainerConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<TrainerWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from trainer in (await GetDbSetAsync())
                   join pokemon in (await GetDbContextAsync()).Pokemons on trainer.PokemonId equals pokemon.Id into pokemons
                   from pokemon in pokemons.DefaultIfEmpty()

                   select new TrainerWithNavigationProperties
                   {
                       Trainer = trainer,
                       Pokemon = pokemon
                   };
        }

        protected virtual IQueryable<TrainerWithNavigationProperties> ApplyFilter(
            IQueryable<TrainerWithNavigationProperties> query,
            string filterText,
            string name = null,
            Guid? pokemonId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Trainer.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Trainer.Name.Contains(name))
                    .WhereIf(pokemonId != null && pokemonId != Guid.Empty, e => e.Pokemon != null && e.Pokemon.Id == pokemonId);
        }

        public async Task<List<Trainer>> GetListAsync(
            string filterText = null,
            string name = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TrainerConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            Guid? pokemonId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, pokemonId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Trainer> ApplyFilter(
            IQueryable<Trainer> query,
            string filterText,
            string name = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name));
        }
    }
}