namespace WellSpringPond.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserLocation
    {
        [Key]
        public int Id { get; set; }

        // [DECIMAL(12, 9)]
        public decimal Latitude { get; set; }
      
        public decimal Longtitude { get; set; }

        public decimal Altitude { get; set; }
    }
}
