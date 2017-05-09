﻿namespace WellSpringPond.Models.BindingModels
{
    using WellSpringPond.Models.EntityModels;

    public class WaterSourceQuickAddBm
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public bool IsDrinkable { get; set; }

        public string author { get; set; }
    }
}
