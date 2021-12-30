using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System;

namespace Pokeee.Web.Pages.Infomation
{
    public class IndexModel : PageModel
    {
        public SampleModel MyModel { get; set; }
        public List<SelectListItem> CityList { get; set; }
        [BindProperty]
        public DetailedModel MyDetailedModel { get; set; }
        public ContactModel MyContactModel { get; set; }
        public void OnGet()
        {
            MyModel = new SampleModel();
            CityList = new List<SelectListItem>
            {
                new SelectListItem { Value = "NY", Text = "New York"},
                new SelectListItem { Value = "LDN", Text = "London"},
                new SelectListItem { Value = "IST", Text = "Istanbul"},
                new SelectListItem { Value = "MOS", Text = "Moscow"}
            };
            MyModel.CityRadio = "IST";
            MyModel.CityRadio2 = "MOS";

            MyDetailedModel = new DetailedModel
            {
                Name = "Sang",
                Description = "Lorem ipsum dolor sit amet.",
                IsActive = true,
                Age = 65,
                Day = DateTime.Now,
                MyCarType = CarType.Coupe,
                YourCarType = CarType.Sedan,
                Country = "RU",
                NeighborCountries = new List<string>() { "NY", "LDN" }
            };

            MyContactModel = new ContactModel();
        }

        public class SampleModel
        {
            [Required]
            
            [Placeholder("Enter your name...")]
            [InputInfoText("What is your name?")]
            public string Name { get; set; }

            [Required]
            [FormControlSize(AbpFormControlSize.Large)]
            public string SurName { get; set; }

            [TextArea(Rows = 4)]
            public string Description { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool IsActive { get; set; }

            public string City { get; set; }

            [SelectItems(nameof(CityList))]
            public string AnotherCity { get; set; }

            public List<string> MultipleCities { get; set; }

            public CarType MyCarType { get; set; }

            public CarType? MyNullableCarType { get; set; }

            public string CityRadio { get; set; }

            [SelectItems(nameof(CityList))]
            public string CityRadio2 { get; set; }
        }
        public class DetailedModel
        {
            [Required]
            [MinLength(3, ErrorMessage = "Name should be more than or equal to 3 characters.")]
            [DisplayOrder(10000)]
            [Placeholder("Enter your name...")]
            [Display(Name = "Name")]
            public string Name { get; set; }
           

            [TextArea(Rows = 4)]
            [DynamicFormIgnore]
            [Display(Name = "Description")]
            [InputInfoText("Describe Yourself")]
            public string Description { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Is Active")]
            public bool IsActive { get; set; }

            [Required]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required]
            [Display(Name = "My Car Type")]
            public CarType MyCarType { get; set; }

            [Required]
            [AbpRadioButton(Inline = true)]
            [Display(Name = "Your Car Type")]
            public CarType YourCarType { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Day")]
            public DateTime Day { get; set; }

            [SelectItems(nameof(CityList))]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [SelectItems(nameof(CityList))]
            [Display(Name = "Neighbor Countries")]
            public List<string> NeighborCountries { get; set; }
        }
        public class ContactModel
        {
            public string Name { get; set; }
        }
        public enum CarType
        {
            Sedan,
            Hatchback,
            StationWagon,
            Coupe
        }
        

    }
}
