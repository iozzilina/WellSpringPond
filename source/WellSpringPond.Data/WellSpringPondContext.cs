namespace WellSpringPond.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
   using WellSpringPond.Models.EntityModels;

    public class WellSpringPondContext : IdentityDbContext<ApplicationUser>
    {
        // Your context has been configured to use a 'WellSpringPondContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WellSpringPond.Data.WellSpringPondContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WellSpringPondContext' 
        // connection string in the application configuration file.
        
        public WellSpringPondContext()
           : base("name=WellSpringPond", throwIfV1Schema: false)
        {
          // Database.SetInitializer<WellSpringPondContext>(new DropCreateDatabaseIfModelChanges<WellSpringPondContext>());
        }

        public static WellSpringPondContext Create()
        {
            return new WellSpringPondContext();
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<WaterSource> WaterSources { get; set; }
        public virtual DbSet<WaterSourceType> WaterSourceTypes { get; set; }
        public virtual DbSet<WaterSourceEdit> WaterSourceEdits { get; set; }
        public virtual DbSet<Availability> Availabilities { get; set; }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Geolocation>().Property(x => x.Latitude).HasPrecision(12, 9);
            modelBuilder.Entity<Geolocation>().Property(x => x.Longtitude).HasPrecision(12, 9);

            base.OnModelCreating(modelBuilder);
        }


    }
}