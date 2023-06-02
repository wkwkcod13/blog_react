using System.Collections;
using System.Collections.ObjectModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace blog_api.Models
{
    public class SocketDevice
    {
        private WebSocket _socket;
        public string Device { get; private set; }
        public string Status => GetConnectionStatus().ToString();
        public string SubProtocol => GetSubProtocol();
        private static JsonSerializerOptions _defaultSerializerOptions() => new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = false };
        public JsonSerializerOptions SerializerOptions { get; internal set; }
        public delegate Task ReceiveAction(SocketDevice device, byte[] data);
        public event ReceiveAction OnReceive = defaultReceivedAction;
        public SocketDevice(WebSocket socket, string device, JsonSerializerOptions? serializerOptions = null)
        {
            this._socket = socket;
            this.Device = device;
            this.SerializerOptions = serializerOptions ?? _defaultSerializerOptions();
        }
        internal string GetSubProtocol()
        {
            return _socket?.SubProtocol ?? "";
        }
        public WebSocketState GetConnectionStatus()
        {
            return _socket?.State ?? WebSocketState.None;
        }
        public async Task ReceiveAsync(ReceiveAction? excuteAction = null)
        {
            Queue<Array> receiveTemp = new Queue<Array>();
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                var segment = new byte[result.Count];
                Array.Copy(buffer, 0, segment, 0, result.Count);
                receiveTemp.Enqueue(segment);

                if (result.EndOfMessage)
                {
                    int length = receiveTemp.Sum(item => item.Length);
                    byte[] combine = new byte[length];
                    int index = 0;
                    while (receiveTemp.Count > 0)
                    {
                        var topTemp = receiveTemp.Dequeue();
                        Array.Copy(topTemp, 0, combine, index, topTemp.Length);
                        index += topTemp.Length;
                    }

                    await OnReceive(this, combine);
                }
                result = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);//next receive data
            }
            await _socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
        public async Task SendAsync<T>(T obj) where T : class
        {
            if (obj is string text)
            {
                await SendAsync(Encoding.UTF8.GetBytes(text));
            }
            else
            {
                string json = JsonSerializer.Serialize(obj, SerializerOptions);
                await SendAsync(Encoding.UTF8.GetBytes(json));
            }
        }
        public async Task SendAsync(byte[] bytes)
        {
            if (GetConnectionStatus() == WebSocketState.Open)
            {
                await _socket.SendAsync(bytes, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public static bool operator ==(SocketDevice obj, SocketDevice other)
        {
            if (obj is null) throw new NullReferenceException();
            if (other is null) return false;
            return obj.Equals(other);
        }
        public static bool operator !=(SocketDevice obj, SocketDevice other) { return !(obj == other); }
        public override bool Equals(object? obj)
        {
            return obj is SocketDevice socket ? this.Device.Equals(socket.Device) : false;
        }
        public override int GetHashCode()
        {
            return Device.GetHashCode();
        }
        private static Task defaultReceivedAction(SocketDevice device, byte[] bytes)
        {
            return Task.CompletedTask;
        }
    }
}
