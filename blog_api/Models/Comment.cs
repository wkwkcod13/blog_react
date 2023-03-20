namespace blog_api.Models
{
    public class Comment : IComment
    {
        public string Id { get; set; }
        public string AutorName { get; set; }
        public string PhotoUrl { get; set; }
        public string Content { get; set; }
        public DateTime Dates { get; set; }
        public Comment ReplyComment { get; set; }
        public Emoji[] Emojis { get; set; }
    }
}
