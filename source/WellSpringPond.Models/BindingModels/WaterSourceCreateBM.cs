namespace WellSpringPond.Models.BindingModels
{
    using WellSpringPond.Models.EntityModels;

    class WaterSourceCreateBM
    {
        public string Name { get; set; }

        public virtual WaterSourceType WaterSourceType { get; set; }
   
        public Geolocation Location { get; set; }

        public decimal Temperature { get; set; }

        public string MineralContent { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
