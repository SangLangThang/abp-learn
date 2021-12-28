using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pokeee.Data;
using Volo.Abp.DependencyInjection;

namespace Pokeee.EntityFrameworkCore
{
    public class EntityFrameworkCorePokeeeDbSchemaMigrator
        : IPokeeeDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCorePokeeeDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the PokeeeDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<PokeeeDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
