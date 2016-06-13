using System;
using UnityEngine;
using WebSocketSharp;

namespace Chat
{
    /// <summary>
    /// Wrapps the socket with strong typing
    /// </summary>
    public class ChatClient
    {
        public event Action<ChatModel> OnChat = delegate { };

        public event Action OnOpen = delegate { };

        public event Action OnClose = delegate { };
        
        //
        
        private WebSocket _socket;
        
        //

        public void Open(string url)
        {
            Close();

            _socket = new WebSocket(url);

            _socket.OnOpen += _socket_OnOpen;
            _socket.OnClose += _socket_OnClose;
            _socket.OnMessage += _socket_OnMessage;
            _socket.OnError += _socket_OnError;

            _socket.Connect();
        }

        public void Close()
        {
            if (_socket != null)
            {
                _socket.OnOpen -= _socket_OnOpen;
                _socket.OnClose -= _socket_OnClose;
                _socket.OnMessage -= _socket_OnMessage;
                _socket.OnError -= _socket_OnError;

                _socket.Close();
                _socket = null;
                OnClose();
            }
        }

        public void Send(ChatModel model)
        {
            if (_socket != null)
                _socket.Send(JsonUtility.ToJson(model));
        }

        //

        private void _socket_OnError(object sender, ErrorEventArgs e)
        {
            MonoHelper.InvokeOnMainThread(() =>
            {
                Debug.LogException(e.Exception);
            });
        }
        
        private void _socket_OnMessage(object sender, MessageEventArgs e)
        {
            MonoHelper.InvokeOnMainThread(() =>
            {
                ChatModel model = JsonUtility.FromJson<ChatModel>(e.Data);
                OnChat(model);
            });
        }

        private void _socket_OnClose(object sender, CloseEventArgs e)
        {
            MonoHelper.InvokeOnMainThread(OnClose);
        }

        private void _socket_OnOpen(object sender, EventArgs e)
        {
            MonoHelper.InvokeOnMainThread(OnOpen);
        }
    }
}
