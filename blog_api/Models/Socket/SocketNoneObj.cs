namespace blog_api.Models.Socket
{
    public class SocketNoneObj : SocketBaseObj, ISocketBase<SocketReceivesTypes, object>
    {
        public override SocketReceivesTypes ActionType => SocketReceivesTypes.None;
        public override object Data => "";
    }
}
