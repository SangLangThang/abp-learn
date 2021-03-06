using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.Caching;

namespace Volo.FileManagement
{
    [DependsOn(
        typeof(FileManagementDomainModule),
        typeof(FileManagementApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpCachingModule)
        )]
    public class FileManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<FileManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<FileManagementApplicationModule>(validate: true);
            });
        }
        
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            
        }
    }
}
