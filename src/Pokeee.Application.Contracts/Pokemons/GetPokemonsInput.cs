using Volo.Abp.Application.Dtos;
using System;

namespace Pokeee.Pokemons
{
    public class GetPokemonsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Avatar { get; set; }
        public string Name { get; set; }
        public int? SlotMin { get; set; }
        public int? SlotMax { get; set; }
        public string Type { get; set; }

        public GetPokemonsInput()
        {

        }
    }
}