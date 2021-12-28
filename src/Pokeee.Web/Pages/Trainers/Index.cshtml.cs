using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Pokeee.Trainers;
using Pokeee.Shared;

namespace Pokeee.Web.Pages.Trainers
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }
        [SelectItems(nameof(PokemonLookupList))]
        public Guid PokemonIdFilter { get; set; }
        public List<SelectListItem> PokemonLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, "")
        };

        private readonly ITrainersAppService _trainersAppService;

        public IndexModel(ITrainersAppService trainersAppService)
        {
            _trainersAppService = trainersAppService;
        }

        public async Task OnGetAsync()
        {
            PokemonLookupList.AddRange((
                    await _trainersAppService.GetPokemonLookupAsync(new LookupRequestDto
                    {
                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
            );

            await Task.CompletedTask;
        }
    }
}