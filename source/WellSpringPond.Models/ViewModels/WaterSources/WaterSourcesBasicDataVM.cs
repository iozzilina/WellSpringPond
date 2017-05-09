namespace WellSpringPond.Models.ViewModels.WaterSources
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using WellSpringPond.Models.EntityModels;

    public class WaterSourcesBasicDataVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Type")]
        public WaterSourceType WaterSourceType { get; set; }

        [Display(Name = "Coordinates")]
        public Geolocation Location { get; set; }

        //eventually get from Google API
        public string LandmarkName { get; set; }
        public string LandmarkCountry { get; set; }

        //eventually get from Google API
        [Display(Name = "Distance")]
        public decimal DistanceFromSearchLocation { get; set; }

        [Display(Name = "Drinkable")]
        public bool IsSafeToDrink { get; set; }

        [Display(Name = "Last Edit Date")]
        public DateTime LastEditDate { get; set; }
    }
}
