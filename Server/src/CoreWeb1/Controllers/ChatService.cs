using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using CoreWeb1.Data;
using Microsoft.AspNetCore.Http;

namespace CoreWeb1.Controllers
{
    public class ChatService
    {
        static List<ChatClient> _connections = new List<ChatClient>();
        static object _lock = new object();

        public static async Task ChatHandler(HttpContext http, Func<Task> next)
        {
            // is this http request a WS request ?
            if (http.WebSockets.IsWebSocketRequest)
            {
                //Accept handshake
                var webSocket = await http.WebSockets.AcceptWebSocketAsync();
                
                // sanity for failed handshake
                if (webSocket != null && webSocket.State == WebSocketState.Open)
                {
                    //make a new client reference
                    var client = new ChatClient(webSocket, bytes =>
                    {
                        //receive handler
                        //here we just broadcast the new message to everyone
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

                    //while open 'Update' (read the incoming socket stream)
                    await client.UpdateAsync();
                   
                    //note, this returns only when the stream is closed
                    
                    //dispose, remove, close
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
