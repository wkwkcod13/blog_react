using System.Text.Json.Serialization;

namespace blog_api.Models
{
    public interface ICalendarEvent
    {
        [JsonPropertyName("id")]
        string Id { get; set; }

        [JsonPropertyName("title")]
        string Title { get; set; }
        [JsonPropertyName("url")]
        string Url { get; set; }

        [JsonPropertyName("start")]
        DateTime StartDate { get; set; }

        [JsonPropertyName("end")]
        DateTime EndDate { get; set; }
    }
}
