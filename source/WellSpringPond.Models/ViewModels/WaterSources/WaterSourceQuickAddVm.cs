namespace WellSpringPond.Models.ViewModels.WaterSources
{
    using System.Collections.Generic;

    public class WaterSourceQuickAddVm
    {
        public string Name { get; set; }

        public string Type { get; set; }
        
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public bool IsDrinkable { get; set; }

        public List<string> WaterTypesDropDown { get; set;}
     }
}
