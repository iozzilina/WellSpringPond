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

        protected override void Seed(WellSpringPond.Data.WellSpringPondContext context)
        {
            RoleData.SeedRoles(context);
            UserData.SeedUsers(context);

            WaterData.SeedWaterSourseTypes(context);
            WaterData.SeedWaterSources(context);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
