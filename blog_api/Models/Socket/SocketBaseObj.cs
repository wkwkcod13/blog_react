using blog_api.Models.Converter;
using System.Text.Json.Serialization;

namespace blog_api.Models.Socket
{
    [JsonConverter(typeof(SocketActionBaseConverter))]
    public class SocketBaseObj : ISocketBase<SocketReceivesTypes, object>
    {
        public SocketReceivesTypes ActionType { get; set; }

        public object Data { get; set; }
    }
}
