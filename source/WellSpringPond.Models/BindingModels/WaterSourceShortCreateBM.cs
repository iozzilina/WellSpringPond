namespace WellSpringPond.Models.BindingModels
{
    using WellSpringPond.Models.EntityModels;

    class WaterSourceShortCreateBm
    {
        public string Name { get; set; }

        public WaterSourceType WaterSourceType { get; set; }
   
        public Geolocation Location { get; set; }
    }
}
