namespace WellSpringPond.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading;

    public class WaterSource
    {
        public WaterSource()
        {
           this.Comments = new List<Comment>();
           this.Edits = new List<WaterSourceEdit>();
        }
       
        public int Id { get; set; }

        public string PlaceId { get; set; }

        public string Name { get; set; }

        public virtual WaterSourceType WaterSourceType{ get; set; }

        //lat / long/ alt
        public virtual Geolocation Location { get; set; }
        
        public virtual Availability Availability { get; set; }

        public decimal Temperature { get; set; }

        public string MineralContent { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual ICollection<WaterSourceEdit> Edits { get; set; }
        
    }
}
