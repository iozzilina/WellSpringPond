namespace WellSpringPond.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using WellSpringPond.Models.BindingModels;
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
        
        public IEnumerable<WaterSourcesBasicDataVm> GetRecent5()
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
                    LastEditDate = RecentEditDate(water)
                };

                vms.Add(vm);
            }

            var rvms = vms.OrderBy(v => v.LastEditDate).Take(5);

            return rvms;
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

        public void QuickAddWaterSource(WaterSourceQuickAddBm bind)
        {
            WaterSource newSource = new WaterSource();
            WaterSourceType waterType = this.Context.WaterSourceTypes.FirstOrDefault(t => t.DisplayName == bind.Type);
            ApplicationUser author = this.Context.Users.FirstOrDefault(u => u.UserName == bind.author);


            Geolocation waterLocation = new Geolocation()
            {
                Latitude = bind.Latitude,
                Longtitude = bind.Longitude
            };
            
            newSource.Name = bind.Name;
            newSource.WaterSourceType = waterType;
            newSource.IsSafeToDrink = bind.IsDrinkable;
            newSource.Location = waterLocation;
            newSource.Availability = this.DefautAvailability();


            WaterSourceEdit creationEdit = new WaterSourceEdit();
            creationEdit.WaterSource = newSource;
            creationEdit.Date = DateTime.Now;
            creationEdit.Author = author;

            newSource.Edits.Add(creationEdit);

            this.Context.WaterSources.Add(newSource);
            this.Context.SaveChanges();
        }

       //helpers

        private static DateTime RecentEditDate(WaterSource water)
        {
            DateTime lastEditDate;

            var waterSourceEdit = water.Edits.OrderByDescending(e => e.Date).FirstOrDefault();
            if (waterSourceEdit != null)
            {
                lastEditDate = waterSourceEdit.Date;
            }

            else
            {
                lastEditDate = new DateTime(2013, 06, 04);
            }
            
            return lastEditDate;
        }

        public List<string> GetDropDownListForWaterTypes()
        {
            IEnumerable<WaterSourceType> waterTypes = this.Context.WaterSourceTypes;

            List<string> waterTypeslist = new List<string>();
            foreach (var type in waterTypes)
            {
                waterTypeslist.Add(type.DisplayName);
            }
            
            return waterTypeslist;
        }

        private decimal CalculateDistance(WaterSource water, Geolocation searchLocation)
        {
            Random rnd = new Random();

            return rnd.Next(1, 100);
        }
        
        public Availability DefautAvailability()
        {
            Availability defautAvailability =
                new Availability()
                {
                    Jan = YesMaybeNo.Maybe,
                    Feb = YesMaybeNo.Maybe,
                    Mar = YesMaybeNo.Maybe,
                    Apr = YesMaybeNo.Maybe,
                    May = YesMaybeNo.Maybe,
                    Jun = YesMaybeNo.Maybe,
                    Jul = YesMaybeNo.Maybe,
                    Aug = YesMaybeNo.Maybe,
                    Sep = YesMaybeNo.Maybe,
                    Oct = YesMaybeNo.Maybe,
                    Nov = YesMaybeNo.Maybe,
                    Dec = YesMaybeNo.Maybe
                };

            return defautAvailability;
        }
    }
}
