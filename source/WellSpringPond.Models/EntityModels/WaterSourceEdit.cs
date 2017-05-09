
namespace WellSpringPond.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WaterSourceEdit
    {
        [Key]
        public int Id { get; set;}

        public DateTime Date {get;set;}

        public virtual ApplicationUser Author { get; set; }

        [ForeignKey("WaterSource")]
        public int WaterSourceId { get; set; }

        public virtual WaterSource WaterSource { get; set; }
    }
}
