namespace WellSpringPond.Models.ViewModels.WaterSources
{
    using WellSpringPond.Models.EntityModels;

    class WaterSourcesBasicDataVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WaterSourceType WaterSourceType { get; set; }

        public Geolocation Location { get; set; }

        //eventually get from Google API
        public string LandmarkName { get; set; }

        //eventually get from Google API
        public decimal DistanceFromSearchLocation { get; set; }
    }
}
