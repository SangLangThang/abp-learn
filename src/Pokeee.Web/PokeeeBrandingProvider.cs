using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Pokeee.Web
{
    [Dependency(ReplaceServices = true)]
    public class PokeeeBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Pokeee";
    }
}
