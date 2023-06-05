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
            Utf8JsonReader cloneReader = reader;
            if (cloneReader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            if (!cloneReader.Read() || cloneReader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }
            string propertyName = cloneReader.GetString() ?? "";
            if (propertyName != "ActionType")
            {
                throw new JsonException();
            }
            if (!cloneReader.Read() || cloneReader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }
            SocketReceivesTypes actionType;
            Enum.TryParse(cloneReader.GetString(), out actionType);
            SocketBaseObj convertedObj;
            switch (actionType)
            {
                case SocketReceivesTypes.None:
                    convertedObj = JsonSerializer.Deserialize<SocketNoneObj>(ref reader, options);
                    break;
                case SocketReceivesTypes.TestSend:
                    convertedObj = JsonSerializer.Deserialize<SocketTestSendObj>(ref reader, options);
                    break;
                case SocketReceivesTypes.Heartbeat:
                    convertedObj = JsonSerializer.Deserialize<SocketHeartbeatObj>(ref reader, options);
                    break;
                default:
                    throw new JsonException();

            }

            //SocketBaseObj convertedObj = actionType switch
            //{
            //    SocketReceivesTypes.None => JsonSerializer.Deserialize<SocketNoneObj>(ref reader, options),
            //    SocketReceivesTypes.TestSend => JsonSerializer.Deserialize<SocketTestSendObj>(ref reader, options),
            //    SocketReceivesTypes.Heartbeat => JsonSerializer.Deserialize<SocketHeartbeatObj>(ref reader, options),
            //    _ => throw new JsonException("SocketReceivesTypes deserialize error.")
            //} ?? throw new JsonException("SocketReceivesTypes deserialize error.");

            return convertedObj;
        }

        public override void Write(Utf8JsonWriter writer, SocketBaseObj value, JsonSerializerOptions options)
        {
            SocketReceivesTypes actionTypes = value.ActionType;
            switch (actionTypes)
            {
                case SocketReceivesTypes.None:
                    JsonSerializer.Serialize(writer, value as SocketNoneObj, options); break;
                case SocketReceivesTypes.TestSend:
                    JsonSerializer.Serialize(writer, value as SocketTestSendObj, options); break;
                case SocketReceivesTypes.Heartbeat:
                    JsonSerializer.Serialize(writer, value as SocketHeartbeatObj, options); break;
                default: throw new JsonException("SocketReceivesTypes serialize error.");
            }
        }
    }
}
