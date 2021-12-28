using Volo.Abp.Modularity;

namespace Pokeee
{
    [DependsOn(
        typeof(PokeeeApplicationModule),
        typeof(PokeeeDomainTestModule)
        )]
    public class PokeeeApplicationTestModule : AbpModule
    {

    }
}