namespace WellSpringPond.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.WaterSources;

    public class WaterSourceService : Service
    {
      
        public IEnumerable<WaterSourcesBasicDataVm> GetWsBasicData()
        {
            IEnumerable<WaterSource> waters = this.Context.WaterSources;

            HashSet<WaterSourcesBasicDataVm> vms = new HashSet<WaterSourcesBasicDataVm>();
            
            foreach (var water in waters)
            {
                WaterSourcesBasicDataVm vm = new WaterSourcesBasicDataVm
                {
                    Id = water.Id,
                    Name = water.Name,
                    WaterSourceType = water.WaterSourceType,
                    Location = water.Location,
                    IsSafeToDrink = water.IsSafeToDrink,
                    LandmarkName = "City",
                    LandmarkCountry = "Country",
                };
                vms.Add(vm);
            }

            var ovms = vms.OrderBy(v => v.WaterSourceType.Id).ThenBy(v=>v.LandmarkCountry);

            return ovms;
        }

        public IEnumerable<WaterSourcesBasicDataVm> GetClosest10(Geolocation searchLocation)
        {
            IEnumerable<WaterSource> waters = this.Context.WaterSources;
            
            HashSet<WaterSourcesBasicDataVm> vms = new HashSet<WaterSourcesBasicDataVm>();
            
            foreach (var water in waters)
            {
                WaterSourcesBasicDataVm vm = new WaterSourcesBasicDataVm
                {
                    Id = water.Id,
                    Name = water.Name,
                    WaterSourceType = water.WaterSourceType,
                    Location = water.Location,
                    IsSafeToDrink = water.IsSafeToDrink,
                    LandmarkName = "City",
                    LandmarkCountry = "Country",
                    DistanceFromSearchLocation = this.CalculateDistance(water, searchLocation)
                };

                vms.Add(vm);
            }

            var ovms = vms.OrderBy(v => v.DistanceFromSearchLocation).Take(10);
           
            return ovms;
        }

        private decimal CalculateDistance(WaterSource water, Geolocation searchLocation)
        {
            Random rnd = new Random();

            return rnd.Next(1, 100);
        }


        //helpers

        public WaterSourcesAdminDataVm GetWsAdminData(int id)
        {
            WaterSource ws = this.Context.WaterSources.Find(id);

            if (ws == null)
            {
                return null;
            }

            WaterSourcesAdminDataVm vm = new WaterSourcesAdminDataVm
            {
                Id = ws.Id,
                Name = ws.Name,
                WaterSourceType = ws.WaterSourceType
            };

            //WaterSourcesAdminDataVm vm = Mapper.Map<WaterSource, WaterSourcesAdminDataVm>(ws);

            return vm;

        }
    }
}
