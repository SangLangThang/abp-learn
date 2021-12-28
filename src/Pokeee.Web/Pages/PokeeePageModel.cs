using Pokeee.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Pokeee.Web.Pages
{
    public abstract class PokeeePageModel : AbpPageModel
    {
        protected PokeeePageModel()
        {
            LocalizationResourceType = typeof(PokeeeResource);
        }
    }
}