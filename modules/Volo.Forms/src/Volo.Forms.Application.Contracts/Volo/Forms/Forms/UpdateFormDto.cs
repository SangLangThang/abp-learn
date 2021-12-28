using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Volo.Forms.Forms
{
    public class UpdateFormDto : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(FormConsts.MaxTitleLength)]
        public string Title { get; set; }
        
        [StringLength(FormConsts.MaxDescriptionLength)]
        public string Description { get; set; }
        

        public string ConcurrencyStamp { get; set; }
    }
}