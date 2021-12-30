using Pokeee.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokeee.Trainers;

namespace Pokeee.Web.Pages.Trainers
{
    public class CreateModalModel : PokeeePageModel
    {
        [BindProperty]
        public TrainerCreateDto Trainer { get; set; }

        public List<SelectListItem> PokemonLookupListRequired { get; set; } = new List<SelectListItem>
        {
        };

        private readonly ITrainersAppService _trainersAppService;

        public CreateModalModel(ITrainersAppService trainersAppService)
        {
            _trainersAppService = trainersAppService;
        }
        
        public async Task OnGetAsync()
        {
            Trainer = new TrainerCreateDto();
            PokemonLookupListRequired.AddRange((
                await _trainersAppService.GetPokemonLookupAsync(new LookupRequestDto
                {
                    MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
            );

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _trainersAppService.CreateAsync(Trainer);
            return NoContent();
        }
    }
}