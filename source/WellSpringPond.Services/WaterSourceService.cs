namespace WellSpringPond.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WellSpringPond.Models.BindingModels;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.Comments;
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
                    LandmarkName = this.GetLandmarkName(water),
                    LandmarkCountry = this.GetLandmarkCountry(water),
                };
                vms.Add(vm);
            }

            var ovms = vms.OrderBy(v => v.WaterSourceType.Id).ThenBy(v=>v.LandmarkCountry);

            return ovms;
        }

        public WaterSourcesDetailDataVm GetWsDetailData(int id)
        {
            WaterSource water = this.Context.WaterSources.FirstOrDefault(ws => ws.Id == id);
            
            if (water != null)
            {
                WaterSourcesDetailDataVm vm = new WaterSourcesDetailDataVm()
                {
                    //this is the wrong id. should be the listing number of the marker on the map, if one exists.
                    Id = water.Id,
                    Name = water.Name,
                    Location = water.Location,
                    WaterSourceType = water.WaterSourceType,
                    LandmarkName = this.GetLandmarkName(water),
                    LandmarkCountry = this.GetLandmarkCountry(water),
                    IsSafeToDrink = water.IsSafeToDrink,
                    Availability = water.Availability,
                    Temperature = water.Temperature,
                    MineralContent = water.MineralContent,
                    Description = water.Description,
                    CreationEdit = this.GetOldestEdit(water),
                    LastUpdate = this.GetNewestEdit(water),
                    ImageUrl = water.ImageUrl,
                    Comments = this.GetComments(water)
                }; 
                return vm;
            }
            else
            {
                return null;
            }
        }

        private List<CommentVm> GetComments(WaterSource water)
        {
            //IEnumerable<CommentVm> waterComments = this.Context.Comments
            //    .Where(w => w.WaterSource == water)
            //    .Include("Users")
            //    .OrderByDescending(d => d.DatePosted).Select(c => new CommentVm()
            //    {
            //        Id = c.Id,
            //        Author = c.Author.UserName,
            //        DatePosted = c.DatePosted,
            //        CommentText = c.CommentText
            //    });

            //List<CommentVm> vms = waterComments.ToList();

            var waterSource = this.Context.WaterSources.FirstOrDefault(w => w.Id == water.Id);
            List<CommentVm> vms = new List<CommentVm>();
            if (waterSource != null)
            {
                IEnumerable<Comment> comments = waterSource.Comments;
                foreach (var comment in comments)
                {
                       vms.Add(new CommentVm()
                        {
                            Id = comment.Id,
                            Author = comment.Author.UserName,
                            DatePosted = comment.DatePosted,
                            CommentText = comment.CommentText
                        });
                }
            }
            return vms;
        }

        
        private WaterSourceEdit GetNewestEdit(WaterSource water)
        {
            var waterSource = this.Context.WaterSources.FirstOrDefault(w => w.Id == water.Id);
            if (waterSource != null)
            {
                IEnumerable<WaterSourceEdit> edits = waterSource.Edits;

                WaterSourceEdit newest = edits.OrderByDescending(e => e.Date).FirstOrDefault();
                return newest;
            }
            else
            {
                return null;
            }
        }
    

        private WaterSourceEdit GetOldestEdit(WaterSource water)
        {
            var waterSource = this.Context.WaterSources.FirstOrDefault(w=>w.Id == water.Id);
            if (waterSource != null)
            {
                IEnumerable<WaterSourceEdit> edits = waterSource.Edits;

                WaterSourceEdit oldest = edits.OrderBy(e => e.Date).FirstOrDefault();
                return oldest;
            }
            else
            {
                return null;
            }
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
                    LandmarkName = this.GetLandmarkName(water),
                    LandmarkCountry = this.GetLandmarkCountry(water),
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
                    LandmarkName = this.GetLandmarkName(water),
                    LandmarkCountry = this.GetLandmarkCountry(water),
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

        private string GetLandmarkName(WaterSource water)
        {
            return "City";
        }

        private string GetLandmarkCountry(WaterSource water)
        {
            return "Country";
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
