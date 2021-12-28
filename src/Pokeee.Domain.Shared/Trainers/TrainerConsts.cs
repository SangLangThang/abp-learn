namespace Pokeee.Trainers
{
    public static class TrainerConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Trainer." : string.Empty);
        }

    }
}