using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace blog_api.Models.Test
{
    public class IMessageConverter : JsonConverter<IMessage>
    {
        public override IMessage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Deserialize the JSON into a dictionary
            Dictionary<string, JsonElement> dictionary = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(ref reader, options);

            // Check the type of the message
            if (dictionary.ContainsKey("Type"))
            {
                string messageType = dictionary["Type"].GetString();
                switch (messageType)
                {
                    case "TextMessage":
                        // Deserialize into a TextMessage
                        return JsonSerializer.Deserialize<TextMessage>(dictionary["Data"].GetRawText(), options);
                    case "PhotoMessage":
                        // Deserialize into a PhotoMessage
                        return JsonSerializer.Deserialize<PhotoMessage>(dictionary["Data"].GetRawText(), options);
                }
            }

            // Throw an exception if the message type is not specified or unrecognized
            throw new JsonException($"Invalid or missing message type for IMessage.");
        }

        public override void Write(Utf8JsonWriter writer, IMessage value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value is TextMessage textMessage)
            {
                writer.WriteString("Type", "TextMessage");
                writer.WritePropertyName("Data");
                JsonSerializer.Serialize(writer, textMessage, options);
            }
            else if (value is PhotoMessage photoMessage)
            {
                writer.WriteString("Type", "PhotoMessage");
                writer.WritePropertyName("Data");
                JsonSerializer.Serialize(writer, photoMessage, options);
            }
            else
            {
                throw new JsonException($"Unknown IMessage implementation: {value.GetType().Name}");
            }

            writer.WriteEndObject();
        }
    }
}
