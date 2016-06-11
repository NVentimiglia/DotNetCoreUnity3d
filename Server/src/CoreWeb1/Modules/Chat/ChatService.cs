using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using CoreWeb1.Modules.Chat;
using Microsoft.AspNetCore.Http;

namespace CoreWeb1
{
    public class ChatService
    {
        static List<ChatClient> _connections = new List<ChatClient>();
        static object _lock = new object();

        public static async Task ChatHandler(HttpContext http, Func<Task> next)
        {
            if (http.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await http.WebSockets.AcceptWebSocketAsync();
                
                if (webSocket != null && webSocket.State == WebSocketState.Open)
                {
                    //make a new client
                    var client = new ChatClient(webSocket, bytes =>
                    {
                        //broadcast new message
                        lock (_lock)
                        {
                            _connections.ForEach(o => o.Send(bytes));
                        }
                    });

                    //add it to mgmt
                    lock (_lock)
                    {
                        _connections.Add(client);
                    }

                    //while open
                    await client.UpdateAsync();
                    
                    //remove on close
                    client.Dispose();
                    lock (_lock)
                    {
                        _connections.Remove(client);
                    }
                }
            }
            else
            {
                // Nothing to do here, pass downstream.  
                await next();
            }
        }
    }
}
