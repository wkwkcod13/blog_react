using System.Text.Json.Serialization;

namespace blog_api.Models.Para
{
    public class ParaELogin
    {
        [JsonPropertyName("account")]
        public string Account { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
