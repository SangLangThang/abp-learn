using Pokeee.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Pokeee
{
    [DependsOn(
        typeof(PokeeeEntityFrameworkCoreTestModule)
        )]
    public class PokeeeDomainTestModule : AbpModule
    {

    }
}