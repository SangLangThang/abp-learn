using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Features;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.FileManagement.Authorization;
using Volo.FileManagement.Localization;

namespace Volo.FileManagement.Web.Navigation
{
    public class FileManagementMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return;
            }

            var featureChecker = context.ServiceProvider.GetService<IFeatureChecker>();

            if (!(await featureChecker.IsEnabledAsync(FileManagementFeatures.Enable)))
            {
                return;
            }
            
            var l = context.GetLocalizer<FileManagementResource>();
                
            var fileManagementMenuItem = new ApplicationMenuItem(FileManagementMenuNames.GroupName, l["Menu:FileManagement"], "~/FileManagement", icon: "fa fa-folder-open").RequirePermissions(FileManagementPermissions.DirectoryDescriptor.Default);

            context.Menu.AddItem(fileManagementMenuItem);
        }
    }
}