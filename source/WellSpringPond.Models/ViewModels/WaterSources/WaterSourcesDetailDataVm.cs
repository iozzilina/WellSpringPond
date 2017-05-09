namespace WellSpringPond.Models.ViewModels.WaterSources
{
    using System.Collections.Generic;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.Comments;

    public class WaterSourcesDetailDataVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WaterSourceType WaterSourceType { get; set; }

        public Geolocation Location { get; set; }

        public string Description { get; set; }

        public string LandmarkName { get; set; }

        public string LandmarkCountry { get; set; }

        public Availability Availability { get; set; }

        public decimal Temperature { get; set; }

        public string MineralContent { get; set; }

        public bool IsSafeToDrink { get; set; }

        public string ImageUrl { get; set; }

        public List<CommentVm> Comments { get; set; }

        public WaterSourceEdit CreationEdit { get; set; }

        public WaterSourceEdit LastUpdate { get; set; }
        
    }
}
