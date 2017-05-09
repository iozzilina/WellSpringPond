namespace WellSpringPond.Models.ViewModels.Comments
{
    using System;

    public class CommentVm
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public string Author { get; set; }

        public DateTime DatePosted { get; set; }
       
    }
}
