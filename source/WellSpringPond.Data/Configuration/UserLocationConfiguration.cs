namespace WellSpringPond.Data.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using WellSpringPond.Models.EntityModels;

    class UserLocationConfiguration : EntityTypeConfiguration<UserLocation>
    {
        public UserLocationConfiguration()
        {
            this.ToTable("UserLocations");
            this.Property(x => x.Latitude).HasPrecision(12, 9);
            this.Property(x => x.Longtitude).HasPrecision(12, 9);
        }
    }
}
