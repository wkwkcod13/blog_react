namespace blog_api.Models.Socket
{
    public class SocketHeartbeatObj : SocketBaseObj, ISocketBase<SocketReceivesTypes, string>
    {
        public new SocketReceivesTypes ActionType => SocketReceivesTypes.Heartbeat;
        public new string Data { get; set; } = "aaa";
        public int Count { get; set; } = 0;
    }
}
