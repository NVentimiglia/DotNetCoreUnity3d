using UnityEngine;

namespace Chat
{
    public class ChatDemo : MonoBehaviour
    {
        public string ServerPath = "ws://localhost:58459/";

        public ChatClient _client;

        public string UserName = "NICK";
        public string Message = "HELLO WORLD";
    

        void OnDestroy()
        {
            if (_client != null)
            {
                _client.Close();
                _client.OnClose -= _client_OnClose;
                _client.OnOpen -= _client_OnOpen;
                _client.OnChat -= _client_OnChat;
                _client = null;
            }
        }


        private void _client_OnChat(ChatModel obj)
        {
            Debug.Log(obj.UserName + " : " + obj.Message);
        }

        private void _client_OnOpen()
        {
            Debug.Log("Chat is open");
        }

        private void _client_OnClose()
        {
            Debug.Log("Chat is closed");
        }

        [ContextMenu("Open")]
        public void Open()
        {
            OnDestroy();
            _client = new ChatClient();
            _client.OnClose += _client_OnClose;
            _client.OnOpen += _client_OnOpen;
            _client.OnChat += _client_OnChat;
            _client.Open(ServerPath);
        }

        [ContextMenu("Close")]
        public void Close()
        {
            OnDestroy();
        }

        [ContextMenu("Send")]
        public void Send()
        {
            _client.Send(new ChatModel
            {
                Message = Message,
                UserName = UserName
            });
        }
    }
}
