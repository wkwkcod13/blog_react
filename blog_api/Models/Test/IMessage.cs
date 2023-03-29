using System.Text.Json.Serialization;

namespace blog_api.Models.Test
{
    [JsonConverter(typeof(IMessageConverter))]
    public interface IMessage
    {
        string MessageId { get; }
    }
}
