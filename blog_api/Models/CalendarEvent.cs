using System.Text.Json.Serialization;

namespace blog_api.Models
{
    public class CalendarEvent : ICalendarEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("start")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end")]
        public DateTime EndDate { get; set; }
    }
}
