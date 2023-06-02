using System.Text.Json.Serialization;

namespace blog_api.Models.Socket
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SocketReceivesTypes
    {
        None,
        TestSend,
        Heartbeat,
        SendMessageRead
    }
}
