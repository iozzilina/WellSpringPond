namespace WellSpringPond.Data.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using WellSpringPond.Models.EntityModels;

    class GeolocationConfiguration : EntityTypeConfiguration<Geolocation>
    {
        public GeolocationConfiguration()
        {
            this.ToTable("Geolocations");
            this.Property(x => x.Latitude).HasPrecision(12, 9);
            this.Property(x => x.Longtitude).HasPrecision(12, 9);
        }
    }
}
