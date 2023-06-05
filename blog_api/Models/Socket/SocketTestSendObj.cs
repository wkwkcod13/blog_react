namespace blog_api.Models.Socket
{
    public class SocketTestSendObj : SocketBaseObj, ISocketBase<SocketReceivesTypes, object>
    {
        public override SocketReceivesTypes ActionType => SocketReceivesTypes.TestSend;

        public new object Data { get; set; }
    }
}
