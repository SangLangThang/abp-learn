using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Pokeee.Localization;
using Pokeee.Permissions;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.IdentityServer.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Saas.Host.Navigation;
using Volo.FileManagement.Web.Navigation;
namespace Pokeee.Web.Menus
{
    public class PokeeeMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<PokeeeResource>();

            //Home
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    PokeeeMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fa fa-home",
                    order: 1
                )
            );

            //HostDashboard
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    PokeeeMenus.HostDashboard,
                    l["Menu:Dashboard"],
                    "~/HostDashboard",
                    icon: "fa fa-line-chart",
                    order: 2
                ).RequirePermissions(PokeeePermissions.Dashboard.Host)
            );

            //TenantDashboard
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    PokeeeMenus.TenantDashboard,
                    l["Menu:Dashboard"],
                    "~/Dashboard",
                    icon: "fa fa-line-chart",
                    order: 2
                ).RequirePermissions(PokeeePermissions.Dashboard.Tenant)
            );

            context.Menu.SetSubItemOrder(SaasHostMenuNames.GroupName, 3);

            //Administration
            var administration = context.Menu.GetAdministration();
            administration.Order = 5;

            //Administration->Identity
            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

            //Administration->Identity Server
            administration.SetSubItemOrder(AbpIdentityServerMenuNames.GroupName, 2);

            //Administration->Language Management
            administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 3);

            //Administration->Text Template Management
            administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 4);

            //Administration->Audit Logs
            administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 5);

            //Administration->Settings
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 6);

            context.Menu.AddItem(
                new ApplicationMenuItem(
                    PokeeeMenus.Pokemons,
                    l["Menu:Pokemons"],
                    url: "/Pokemons",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: PokeeePermissions.Pokemons.Default)
            );

            context.Menu.AddItem(
                new ApplicationMenuItem(
                    PokeeeMenus.Trainers,
                    l["Menu:Trainers"],
                    url: "/Trainers",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: PokeeePermissions.Trainers.Default)
            );
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    PokeeeMenus.Infomation,
                    l["Menu:Infomation"],
                    url: "/Infomation",
                    icon: "fa fa-file-alt")
            );
            


            return Task.CompletedTask;
        }
    }
}