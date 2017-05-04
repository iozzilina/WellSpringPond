namespace WellSpringPond.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WellSpringPond.Data.Configuration;
    using WellSpringPond.Models.EntityModels;

    public class WellSpringPondContext : IdentityDbContext<ApplicationUser>
    {
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
        public virtual DbSet<Geolocation> Geolocations { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GeolocationConfiguration());

            // keep this for Authorization module
            base.OnModelCreating(modelBuilder);
        }
    }
}