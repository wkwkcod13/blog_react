namespace blog_api.Models.Socket
{
    public class SocketHeartbeatObj : SocketBaseObj, ISocketBase<SocketReceivesTypes, string>
    {
        public override SocketReceivesTypes ActionType => SocketReceivesTypes.Heartbeat;
        public new string Data { get; set; } = "qqqq";
        public int Count { get; set; } = 0;
    }
}
