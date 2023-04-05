namespace BlogApp.Models
{
    public class UserPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleText { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
