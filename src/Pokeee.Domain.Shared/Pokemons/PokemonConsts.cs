namespace Pokeee.Pokemons
{
    public static class PokemonConsts
    {
        private const string DefaultSorting = "{0}Avatar asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Pokemon." : string.Empty);
        }

    }
}