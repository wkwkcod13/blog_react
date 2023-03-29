namespace blog_api.Models.Test
{
    public interface ITextMessage : IMessage
    {
        string Text { get; set; }
    }
}
