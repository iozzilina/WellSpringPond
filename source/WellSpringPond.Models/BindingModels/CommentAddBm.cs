namespace WellSpringPond.Models.BindingModels
{
    using System;

    public class CommentAddBm
    {
        public int Id { get; set; }

        public int WsID { get; set; }

        public string CommentText { get; set; }

        public string Author { get; set; }

        public DateTime DatePosted { get; set; }

    }
}
