using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using CoreWeb1.Infrastructure.AsyncLock;

namespace CoreWeb1.Modules.Chat
{
    public class ChatClient : IDisposable
    {
        public bool IsOpen
        {
            get { return socket.State == WebSocketState.Open; }
        }

        WebSocket socket;
        byte[] buffer = new byte[1024];
        AsyncLock _lock = new AsyncLock();
        Action<byte[]> onMessage;
        private bool error = false;

        public ChatClient(WebSocket socket, Action<byte[]> onMessage)
        {
            this.socket = socket;
            this.onMessage = onMessage;
        }


        public void Dispose()
        {
            var mSock = socket;
            socket = null;
            if (mSock != null)
                mSock.Dispose();
        }

        public async Task UpdateAsync()
        {
            WebSocketReceiveResult received = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (received.MessageType != WebSocketMessageType.Close && !error)
            {
                if (received.MessageType == WebSocketMessageType.Text)
                {
                    onMessage(buffer);
                }

                received = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
        }

        public async void Send(byte[] message)
        {
            try
            {
                if (socket == null || socket.State != WebSocketState.Open)
                    return;

                //utilize the bytes
                var payload = new ArraySegment<byte>(message, 0, message.Length);

                //can only send one at a time
                using (var releaser = await _lock.LockAsync())
                {
                    await socket.SendAsync(payload, WebSocketMessageType.Text, true, CancellationToken.None);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                error = true;
            }
        }
    }
}
