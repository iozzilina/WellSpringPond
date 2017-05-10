namespace WellSpringPond.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class WaterSourceQuickAddBm
    {
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the type of the watersource.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter a Latitude")]
        [Range(-90.00,90.00,ErrorMessage = "Please enter a valid Latitude")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "Please enter valid Longtitude")]
        [Range(-180.00, 180.00, ErrorMessage = "Please enter a valid Longtitude")]
        public decimal Longitude { get; set; }

        public bool IsDrinkable { get; set; }

        public string author { get; set; }
    }
}
