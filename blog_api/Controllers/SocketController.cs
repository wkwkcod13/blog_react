using blog_api.Models.Socket;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace blog_api.Controllers
{
    [Route("[controller]")]
    public class SocketController : ControllerBase
    {
        public SocketController() { }

        [HttpPost("GetSocketObj")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetSocketObj(SocketReceivesTypes receivesTypes)
        {
            ISocketBase<SocketReceivesTypes, object> socket = receivesTypes switch
            {
                SocketReceivesTypes.None => new SocketNoneObj(),
                SocketReceivesTypes.Heartbeat => new SocketHeartbeatObj(),
                SocketReceivesTypes.TestSend => new SocketTestSendObj(),
                _ => throw new InvalidOperationException()
            };
            return new JsonResult(socket);
        }

        [HttpPost("GetSocketObjList")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetSocketObjList()
        {
            List<SocketBaseObj> sockets = new List<SocketBaseObj>();
            sockets.Add(new SocketHeartbeatObj());
            sockets.Add(new SocketTestSendObj());
            return new JsonResult(sockets);
        }
    }
}
