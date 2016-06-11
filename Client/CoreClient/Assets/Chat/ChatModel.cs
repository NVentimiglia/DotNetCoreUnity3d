using System;
using UnityEngine;

namespace Chat
{
    /// <summary>
    /// Our DTO
    /// </summary>
    [Serializable]
    public class ChatModel
    {
        [SerializeField]
        public string UserName;
        [SerializeField]
        public string Message;
    }
}
