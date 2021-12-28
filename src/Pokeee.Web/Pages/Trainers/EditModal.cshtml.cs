using Pokeee.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Pokeee.Trainers;

namespace Pokeee.Web.Pages.Trainers
{
    public class EditModalModel : PokeeePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public TrainerUpdateDto Trainer { get; set; }

        public List<SelectListItem> PokemonLookupListRequired { get; set; } = new List<SelectListItem>
        {
        };

        private readonly ITrainersAppService _trainersAppService;

        public EditModalModel(ITrainersAppService trainersAppService)
        {
            _trainersAppService = trainersAppService;
        }

        public async Task OnGetAsync()
        {
            var trainerWithNavigationPropertiesDto = await _trainersAppService.GetWithNavigationPropertiesAsync(Id);
            Trainer = ObjectMapper.Map<TrainerDto, TrainerUpdateDto>(trainerWithNavigationPropertiesDto.Trainer);

            PokemonLookupListRequired.AddRange((
                                    await _trainersAppService.GetPokemonLookupAsync(new LookupRequestDto
                                    {
                                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
                        );

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _trainersAppService.UpdateAsync(Id, Trainer);
            return NoContent();
        }
    }
}