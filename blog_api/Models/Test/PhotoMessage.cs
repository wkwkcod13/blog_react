namespace blog_api.Models.Test
{
    public class PhotoMessage : IMessage, IPhotoMessage
    {
        private string _messageId = "";
        public string Uri { get; set; } = "";
        public string MessageId => _messageId;

        public PhotoMessage()
        {

        }
    }
}
