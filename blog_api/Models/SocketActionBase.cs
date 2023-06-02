namespace blog_api.Models
{
    public class SocketActionBase
    {
        public Dictionary<string, string> Data { get; set; }
        public SocketActionBase()
        {
            Data = new Dictionary<string, string>();
        }
    }
}
