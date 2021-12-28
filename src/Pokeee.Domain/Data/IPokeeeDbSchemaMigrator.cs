using System.Threading.Tasks;

namespace Pokeee.Data
{
    public interface IPokeeeDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}