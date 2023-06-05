using Org.BouncyCastle.Utilities;
using System.Text.Json.Serialization;

namespace blog_api.Models.Socket
{
    public interface ISocketBase<T1, T2> where T1 : struct where T2 : class
    {
        T1 ActionType { get; }
        T2 Data { get; set; }
    }
}
