namespace WellSpringPond.Models.ViewModels.WaterSources
{
    using WellSpringPond.Models.EntityModels;

    public class WaterSourcesAdminDataVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WaterSourceType WaterSourceType { get; set; }

        public Geolocation Location { get; set; }

        public string Description { get; set; }

        public Availability Availability { get; set; }

        //eventually get from Google API
        public string LandmarkName { get; set; }
        public string LandmarkCountry{ get; set; }

        //eventually get from Google API
        public decimal DistanceFromSearchLocation { get; set; }
    }
}
