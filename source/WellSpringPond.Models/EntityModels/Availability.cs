namespace WellSpringPond.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Availability
    {
        [Key]
        public int Id { get; set; }

        public YesMaybeNo Jan { get; set; }
        public YesMaybeNo Feb { get; set; }
        public YesMaybeNo Mar { get; set; }
        public YesMaybeNo Apr { get; set; }
        public YesMaybeNo May { get; set; }
        public YesMaybeNo Jun { get; set; }
        public YesMaybeNo Jul { get; set; }
        public YesMaybeNo Aug { get; set; }
        public YesMaybeNo Sep { get; set; }
        public YesMaybeNo Oct { get; set; }
        public YesMaybeNo Nov { get; set; }
        public YesMaybeNo Dec { get; set; }
    }
}
