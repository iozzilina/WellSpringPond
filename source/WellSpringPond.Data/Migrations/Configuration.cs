namespace WellSpringPond.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WellSpringPond.Data.SeedData;

    internal sealed class Configuration : DbMigrationsConfiguration<WellSpringPond.Data.WellSpringPondContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

            //DBCC CHECKIDENT('[TestTable]', RESEED, 0) // reset identity to 0
            

        protected override void Seed(WellSpringPond.Data.WellSpringPondContext context)
        {
            RoleData.SeedRoles(context);
            UserData.SeedUsers(context);

            WaterData.SeedWaterSourseTypes(context);
            WaterData.SeedWaterSources(context);
            //WaterData.SeedEdits(context);
            WaterData.SeedComments(context);
        }
    }
}
