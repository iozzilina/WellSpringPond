namespace WellSpringPond.Models.EntityModels
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public DateTime DatePosted { get; set; }

        public bool IsDeleted { get; set; }

        public virtual WaterSource WaterSource { get; set; }

    }
}
