using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Pokeee.Data
{
    /* This is used if database provider does't define
     * IPokeeeDbSchemaMigrator implementation.
     */
    public class NullPokeeeDbSchemaMigrator : IPokeeeDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}