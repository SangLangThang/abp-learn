﻿using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Studio.ModuleInstalling;

namespace Volo.Chat
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    [ExposeServices(typeof(IModuleInstallingPipelineBuilder))]
    public class ChatInstallerPipelineBuilder : ModuleInstallingPipelineBuilderBase, IModuleInstallingPipelineBuilder, ITransientDependency
    {
        public async Task<ModuleInstallingPipeline> BuildAsync(ModuleInstallingContext context)
        {
            context.AddEfCoreConfigurationMethodDeclaration(
                new EfCoreConfigurationMethodDeclaration(
                    "Volo.Chat.EntityFrameworkCore",
                    "ConfigureChat"
                )
            );
            
            return GetBasePipeline(context);
        }
    }
}
