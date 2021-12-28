using Pokeee.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Pokeee.Permissions
{
    public class PokeeePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(PokeeePermissions.GroupName);

            myGroup.AddPermission(PokeeePermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(PokeeePermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(PokeeePermissions.MyPermission1, L("Permission:MyPermission1"));

            var pokemonPermission = myGroup.AddPermission(PokeeePermissions.Pokemons.Default, L("Permission:Pokemons"));
            pokemonPermission.AddChild(PokeeePermissions.Pokemons.Create, L("Permission:Create"));
            pokemonPermission.AddChild(PokeeePermissions.Pokemons.Select, L("Permission:Select"));
            pokemonPermission.AddChild(PokeeePermissions.Pokemons.Edit, L("Permission:Edit"));
            pokemonPermission.AddChild(PokeeePermissions.Pokemons.Delete, L("Permission:Delete"));

            var trainerPermission = myGroup.AddPermission(PokeeePermissions.Trainers.Default, L("Permission:Trainers"));
            trainerPermission.AddChild(PokeeePermissions.Trainers.Create, L("Permission:Create"));
            trainerPermission.AddChild(PokeeePermissions.Trainers.Edit, L("Permission:Edit"));
            trainerPermission.AddChild(PokeeePermissions.Trainers.Delete, L("Permission:Delete"));

            myGroup.AddPermission(PokeeePermissions.Company.Default, L("Permission:Company"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PokeeeResource>(name);
        }
    }
}