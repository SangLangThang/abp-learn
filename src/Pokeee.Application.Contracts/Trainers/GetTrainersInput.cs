using Volo.Abp.Application.Dtos;
using System;

namespace Pokeee.Trainers
{
    public class GetTrainersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public Guid? PokemonId { get; set; }

        public GetTrainersInput()
        {

        }
    }
}