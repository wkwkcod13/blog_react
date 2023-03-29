namespace blog_api.Models.Test
{
    public class TextMessage : ITextMessage
    {
        private string _messageId = "";
        public string Text { get; set; } = "";
        public string MessageId => _messageId;

        public TextMessage()
        {
        }
    }
}
