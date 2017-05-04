
namespace WellSpringPond.Data.SeedData
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WellSpringPond.Models.EntityModels;

    internal class WaterData
    {
        internal static void SeedWaterSourseTypes(WellSpringPond.Data.WellSpringPondContext context)
        {
            context.WaterSourceTypes.AddOrUpdate(wst => wst.Id,
                new WaterSourceType() {Id = 1, DisplayName = "Stream", ExtendedName = "Free-flowing Stream"},
                new WaterSourceType()
                {
                    Id = 2,
                    DisplayName = "Spring w/o tap",
                    ExtendedName = "Mineral spring without tap"
                },
                new WaterSourceType() {Id = 3, DisplayName = "Spring w/ tap", ExtendedName = "Mineral spring with tap"},
                new WaterSourceType() {Id = 4, DisplayName = "Well", ExtendedName = "Man-made well"},
                new WaterSourceType() {Id = 5, DisplayName = "Pump", ExtendedName = "Water pump"},
                new WaterSourceType() {Id = 6, DisplayName = "City Water", ExtendedName = "Piped municipal water"}
                );
        }

        internal static void SeedWaterSources(WellSpringPond.Data.WellSpringPondContext context)
        {
            WaterSource ws01 = new WaterSource()
            {
                Id = 1,
                Name = "Popova Cheshma",
                WaterSourceType = context.WaterSourceTypes.FirstOrDefault(t => t.Id == 3),
                Location = new Geolocation() {Latitude = 55.231223M, Longtitude = 44.212321M, Altitude = 432M},
                MineralContent = "Unknown"
            };

            WaterSource ws02 = new WaterSource()
            {
                Id = 2,
                Name = "Mirov Dol",
                WaterSourceType = context.WaterSourceTypes.FirstOrDefault(t => t.Id == 1),
                Location = new Geolocation() {Latitude = 55.251223M, Longtitude = 44.222321M, Altitude = 132M},
                MineralContent = "Unknown",
                Availability =
                    new Availability()
                    {
                        Id = 2,
                        Jan = YesMaybeNo.Yes,
                        Feb = YesMaybeNo.Yes,
                        Mar = YesMaybeNo.Yes,
                        Apr = YesMaybeNo.Maybe,
                        May = YesMaybeNo.Maybe,
                        Jun = YesMaybeNo.No,
                        Jul = YesMaybeNo.No,
                        Aug = YesMaybeNo.Maybe,
                        Sep = YesMaybeNo.Maybe,
                        Oct = YesMaybeNo.No,
                        Nov = YesMaybeNo.No,
                        Dec = YesMaybeNo.Maybe
                    }
            };

            WaterSource ws03 = new WaterSource()
            {
                Id = 3,
                Name = "Markova Cheshma",
                WaterSourceType = context.WaterSourceTypes.FirstOrDefault(t => t.Id == 4),
                Location = new Geolocation() { Latitude = 55.312223M, Longtitude = 44.312321M, Altitude = 232M },
                MineralContent = "Unknown",
                Availability =
                    new Availability()
                    {
                        Id = 3,
                        Jan = YesMaybeNo.Yes,
                        Feb = YesMaybeNo.Yes,
                        Mar = YesMaybeNo.Yes,
                        Apr = YesMaybeNo.Yes,
                        May = YesMaybeNo.Yes,
                        Jun = YesMaybeNo.Yes,
                        Jul = YesMaybeNo.Yes,
                        Aug = YesMaybeNo.Maybe,
                        Sep = YesMaybeNo.Yes,
                        Oct = YesMaybeNo.Yes,
                        Nov = YesMaybeNo.Yes,
                        Dec = YesMaybeNo.Yes
                    }
            };


            WaterSource ws04 = new WaterSource()
            {
                Id = 4,
                Name = "Popova Cheshma",
                WaterSourceType = context.WaterSourceTypes.FirstOrDefault(t => t.Id == 5),
                Location = new Geolocation() { Latitude = 55.231223M, Longtitude = 44.212321M, Altitude = 432M },
                MineralContent = "Minty stuff!",
                Description = "This water is very refreshing!",
                Availability =
                    new Availability()
                    {
                        Id = 4,
                        Jan = YesMaybeNo.Yes,
                        Feb = YesMaybeNo.Yes,
                        Mar = YesMaybeNo.Yes,
                        Apr = YesMaybeNo.Yes,
                        May = YesMaybeNo.Yes,
                        Jun = YesMaybeNo.Yes,
                        Jul = YesMaybeNo.Yes,
                        Aug = YesMaybeNo.Maybe,
                        Sep = YesMaybeNo.Yes,
                        Oct = YesMaybeNo.Yes,
                        Nov = YesMaybeNo.Yes,
                        Dec = YesMaybeNo.Yes
                    }
            };

            WaterSource ws05 = new WaterSource()
            {
                Id = 5,
                Name = "Popova Cheshma",
                WaterSourceType= context.WaterSourceTypes.FirstOrDefault(t => t.Id == 6),
                Location = new Geolocation() { Latitude = 55.231223M, Longtitude = 44.212321M, Altitude = 432M },
                MineralContent = "Uranium",
                Availability =
                    new Availability()
                    {
                        Id = 5,
                        Jan = YesMaybeNo.Yes,
                        Feb = YesMaybeNo.Yes,
                        Mar = YesMaybeNo.Yes,
                        Apr = YesMaybeNo.Yes,
                        May = YesMaybeNo.Yes,
                        Jun = YesMaybeNo.Yes,
                        Jul = YesMaybeNo.Yes,
                        Aug = YesMaybeNo.Maybe,
                        Sep = YesMaybeNo.Yes,
                        Oct = YesMaybeNo.Yes,
                        Nov = YesMaybeNo.Yes,
                        Dec = YesMaybeNo.Yes
                    }
            };

            WaterSource ws06 = new WaterSource()
            {
                Id = 6,
                Name = "Popova Cheshma",
                WaterSourceType = context.WaterSourceTypes.FirstOrDefault(t => t.Id == 2),
                Location = new Geolocation() { Latitude = 55.231223M, Longtitude = 44.212321M, Altitude = 432M },
                MineralContent = "Sulpher",
                Availability =
                    new Availability()
                    {
                        Id = 6,
                        Jan = YesMaybeNo.Yes,
                        Feb = YesMaybeNo.Yes,
                        Mar = YesMaybeNo.Yes,
                        Apr = YesMaybeNo.Yes,
                        May = YesMaybeNo.Yes,
                        Jun = YesMaybeNo.Yes,
                        Jul = YesMaybeNo.Yes,
                        Aug = YesMaybeNo.Maybe,
                        Sep = YesMaybeNo.Yes,
                        Oct = YesMaybeNo.Yes,
                        Nov = YesMaybeNo.Yes,
                        Dec = YesMaybeNo.Yes
                    }
            };

            context.WaterSources.AddOrUpdate(ws => ws.Id, ws01);
            context.WaterSources.AddOrUpdate(ws => ws.Id, ws02);
            context.WaterSources.AddOrUpdate(ws => ws.Id, ws03);
            context.WaterSources.AddOrUpdate(ws => ws.Id, ws04);
            context.WaterSources.AddOrUpdate(ws => ws.Id, ws05);
            context.WaterSources.AddOrUpdate(ws => ws.Id, ws06);
        }

        internal static void SeedEdits(WellSpringPond.Data.WellSpringPondContext context)
        {
            //context.WaterSourceTypes.AddOrUpdate(wst => wst.Id,
            // add edits

            List<WaterSourceEdit> edits01 = new List<WaterSourceEdit>()
            {
                new WaterSourceEdit()
                {
                    Id = 1,
                    Date = new DateTime(2015, 06, 04),
                    Author = context.Users.FirstOrDefault(u => u.UserName == "User01@me.com")
                },
                new WaterSourceEdit()
                {
                    Id = 2,
                    Date = new DateTime(2016, 03, 02),
                    Author = context.Users.FirstOrDefault(u => u.UserName == "User02@me.com")
                },
                new WaterSourceEdit()
                {
                    Id = 3,
                    Date = new DateTime(2016, 03, 01),
                    Author = context.Users.FirstOrDefault(u => u.UserName == "User03@me.com")
                }
            };

            WaterSource ws01 = context.WaterSources.FirstOrDefault(ws => ws.Id == 1);

            foreach (var waterSourceEdit in edits01)
            {
                waterSourceEdit.WaterSource = ws01;
            }

            foreach (var waterSourceEdit in edits01)
            {
                context.WaterSourceEdits.AddOrUpdate(wse => wse.Id, waterSourceEdit);
            }

            List<WaterSourceEdit> edits02 = new List<WaterSourceEdit>()
                {
                    new WaterSourceEdit()
                    {
                        Id = 4,
                        Date = new DateTime(2014, 03, 02),
                        Author = context.Users.FirstOrDefault(u => u.UserName == "User01@me.com")
                    },
                    new WaterSourceEdit()
                    {
                        Id = 5,
                        Date = new DateTime(2014, 05, 08),
                        Author = context.Users.FirstOrDefault(u => u.UserName == "User02@me.com")
                    },
                    new WaterSourceEdit()
                    {
                        Id = 6,
                        Date = new DateTime(2016, 03, 05),
                        Author = context.Users.FirstOrDefault(u => u.UserName == "User03@me.com")
                    }
                };

            WaterSource ws02 = context.WaterSources.FirstOrDefault(ws => ws.Id == 2);

            foreach (var waterSourceEdit in edits02)
            {
                waterSourceEdit.WaterSource = ws02;
            }

            foreach (var waterSourceEdit in edits02)
            {
                context.WaterSourceEdits.AddOrUpdate(wse => wse.Id, waterSourceEdit);
            }
        }

        internal static void SeedComments(WellSpringPond.Data.WellSpringPondContext context)
        {

            // add comments
             List<Comment> comments01 = new List<Comment>() {
                new Comment()
                {
                    Id = 1,
                    DatePosted = new DateTime(2016,03,02),
                    Author = context.Users.FirstOrDefault(u=>u.UserName=="User01@me.com"),
                    CommentText = "This water is tasty. I will use this place often."
                },
                new Comment()
                {
                    Id = 2,
                    DatePosted = new DateTime(2016,05,02),
                    Author = context.Users.FirstOrDefault(u=>u.UserName=="User01@me.com"),
                    CommentText = "Nonsence! it tastes horrible!"
                }
            };
            
            WaterSource ws01 = context.WaterSources.FirstOrDefault(ws => ws.Id == 1);

            foreach (var comment in comments01)
            {
                comment.WaterSource = ws01;
            }

            foreach (var comment in comments01)
            {
                context.Comments.AddOrUpdate(c=>c.Id, comment);
            }
        }
    }
}
