using Pokeee.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Pokeee.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(PokeeeEntityFrameworkCoreModule),
        typeof(PokeeeApplicationContractsModule)
    )]
    public class PokeeeDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
