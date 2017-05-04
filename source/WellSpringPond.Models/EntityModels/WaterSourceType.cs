namespace WellSpringPond.Models.EntityModels
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WaterSourceType
    {
        [Key]
        public int Id { get; set; }

        public string DisplayName { get; set; }
        //public string DisplayIcon { get; set; }

        public string ExtendedName { get; set; }

        [NotMapped]
        public virtual IEnumerable<WaterSource> WaterSources { get; set; }
    }
}
