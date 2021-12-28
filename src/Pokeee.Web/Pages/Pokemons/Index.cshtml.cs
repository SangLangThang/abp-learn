using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Pokeee.Pokemons;
using Pokeee.Shared;

namespace Pokeee.Web.Pages.Pokemons
{
    public class IndexModel : AbpPageModel
    {
        public string AvatarFilter { get; set; }
        public string NameFilter { get; set; }
        public int? SlotFilterMin { get; set; }

        public int? SlotFilterMax { get; set; }
        public string TypeFilter { get; set; }

        public bool Bug { get; set; }
        public bool MinSlot10 { get; set; }

        private readonly IPokemonsAppService _pokemonsAppService;

        public IndexModel(IPokemonsAppService pokemonsAppService)
        {
            _pokemonsAppService = pokemonsAppService;
        }
        public List<SelectListItem> CityList { get; set; }
        public async Task OnGetAsync()
        {
            CityList = new List<SelectListItem>
            {
                new SelectListItem { Value = "normal", Text = "normal"},
                new SelectListItem { Value = "fire", Text = "fire"},
                new SelectListItem { Value = "grass", Text = "grass"},
                new SelectListItem { Value = "electric", Text = "electric"},
                new SelectListItem { Value = "water", Text = "water"},
            };
            await Task.CompletedTask;
        }
    }
}