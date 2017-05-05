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

            Random rnd = new Random();

            foreach (var water in waters)
            {
                WaterSourcesBasicDataVm vm = new WaterSourcesBasicDataVm
                {
                    Id = water.Id,
                    Name = water.Name,
                    WaterSourceType = water.WaterSourceType,
                    Location = water.Location,
                    LandmarkName = "City",
                    LandmarkCountry = "Country",
                    DistanceFromSearchLocation = 1.4M+rnd.Next(1,10)
                };

                //vm.Location.Latitude = water.Location.Latitude;
                //vm.Location.Longtitude = water.Location.Longtitude;
                //vm.Location.Altitude = water.Location.Altitude;

                vms.Add(vm);
            }

            var ovms = vms.OrderBy(v => v.DistanceFromSearchLocation);
            // IEnumerable<WaterSourcesBasicDataVm> vms = Mapper.Map<IEnumerable<WaterSource>, IEnumerable<WaterSourcesBasicDataVm>>(waters);

            return ovms;
        }


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
