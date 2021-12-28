using Pokeee.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Pokeee.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class PokeeeController : AbpControllerBase
    {
        protected PokeeeController()
        {
            LocalizationResource = typeof(PokeeeResource);
        }
    }
}