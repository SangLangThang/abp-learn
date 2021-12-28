using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Pokeee.Pokemons;

namespace Pokeee.Web.Pages.Pokemons
{
    public class EditModalModel : PokeeePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public PokemonUpdateDto Pokemon { get; set; }

        private readonly IPokemonsAppService _pokemonsAppService;

        public EditModalModel(IPokemonsAppService pokemonsAppService)
        {
            _pokemonsAppService = pokemonsAppService;
        }

        public async Task OnGetAsync()
        {
            var pokemon = await _pokemonsAppService.GetAsync(Id);
            Pokemon = ObjectMapper.Map<PokemonDto, PokemonUpdateDto>(pokemon);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _pokemonsAppService.UpdateAsync(Id, Pokemon);
            return NoContent();
        }
    }
}