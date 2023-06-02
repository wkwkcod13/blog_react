using blog_api.Models;
using blog_api.Service.Interface;
using iText.Kernel.XMP.Options;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace blog_api.Service
{
    public class SocketService : ISocketService
    {
        private static JsonSerializerOptions _defaultSerializerOptions() => new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = false };
        private static JsonSerializerOptions? _serializeOptions;
        private ConcurrentDictionary<SocketDevice, string> _allDevices;
        private ConcurrentDictionary<string, List<SocketDevice>> _devicesGourpByAuthKey;

        public SocketService(JsonSerializerOptions serializerOptions)
        {
            _allDevices = new ConcurrentDictionary<SocketDevice, string>();
            _devicesGourpByAuthKey = new ConcurrentDictionary<string, List<SocketDevice>>();
            _serializeOptions = serializerOptions ?? _defaultSerializerOptions();
        }

        public async Task ConnectAsync(HttpContext httpContext)
        {
            string ip = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            WebSocket? socket = httpContext.WebSockets.IsWebSocketRequest ?
                await httpContext.WebSockets.AcceptWebSocketAsync() : null;

        }

        private static async Task ReceiveAction(SocketDevice device, byte[] data)
        {
            try
            {
                SocketActionBase? receiveBase = JsonSerializer.Deserialize<SocketActionBase>(data, _serializeOptions) ?? null;
                SocketActionBase feedbackBase = new SocketActionBase();
                if (receiveBase != null && receiveBase.Data.Count > 0)
                {
                    foreach (var item in receiveBase.Data)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                await device.SendAsync(ex.Message);
            }
        }
    }
}
