﻿namespace blog_api.Models
{
    public class Blog : IBlog
    {
        public string BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreateDate { get; set; }
        public HashTag[] Tags { get; set; }
        public Emoji[] Emojis { get; set; }
    }
}
