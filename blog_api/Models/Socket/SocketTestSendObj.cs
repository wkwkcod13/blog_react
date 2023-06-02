namespace blog_api.Models.Socket
{
    public class SocketTestSendObj : SocketBaseObj, ISocketBase<SocketReceivesTypes, object>
    {
        public new SocketReceivesTypes ActionType => SocketReceivesTypes.TestSend;

        public new object Data { get; set; } = "asdfwer";
        public object Data2 { get; set; } = "";
    }
}
