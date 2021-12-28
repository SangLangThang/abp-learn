using Pokeee.Localization;
using Volo.Abp.Application.Services;

namespace Pokeee
{
    /* Inherit your application services from this class.
     */
    public abstract class PokeeeAppService : ApplicationService
    {
        protected PokeeeAppService()
        {
            LocalizationResource = typeof(PokeeeResource);
        }
    }
}
