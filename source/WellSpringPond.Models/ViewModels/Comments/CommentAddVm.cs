namespace WellSpringPond.Models.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentAddVm
    {
        public int Id { get; set; }

        public int WsId { get; set; }

        [Required(ErrorMessage = "Comment cannot be blank")]
        public string CommentText { get; set; }
    }
}
