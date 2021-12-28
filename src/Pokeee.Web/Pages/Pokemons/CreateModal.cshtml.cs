using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokeee.Pokemons;

namespace Pokeee.Web.Pages.Pokemons
{
    public class CreateModalModel : PokeeePageModel
    {
        [BindProperty]
        public PokemonCreateDto Pokemon { get; set; }

        private readonly IPokemonsAppService _pokemonsAppService;

        public CreateModalModel(IPokemonsAppService pokemonsAppService)
        {
            _pokemonsAppService = pokemonsAppService;
        }

        public async Task OnGetAsync()
        {
            Pokemon = new PokemonCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _pokemonsAppService.CreateAsync(Pokemon);
            return NoContent();
        }
    }
}