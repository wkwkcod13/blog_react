using blog_api.Models.Socket;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace blog_api.Models.Converter
{
    public class SocketActionBaseConverter : JsonConverter<SocketBaseObj>
    {
        public override SocketBaseObj? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //TODO
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, SocketBaseObj value, JsonSerializerOptions options)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
