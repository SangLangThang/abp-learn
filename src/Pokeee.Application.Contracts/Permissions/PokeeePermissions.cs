namespace Pokeee.Permissions
{
    public static class PokeeePermissions
    {
        public const string GroupName = "Pokeee";

        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = DashboardGroup + ".Tenant";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Pokemons
        {
            public const string Default = GroupName + ".Pokemons";
            public const string Select = Default + ".Select";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Trainers
        {
            public const string Default = GroupName + ".Trainers";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Company
        {
            public const string Default = GroupName + ".Compnany";
          
        }
    }
}