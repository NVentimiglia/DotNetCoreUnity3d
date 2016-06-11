using System;
using UnityEngine;

namespace Chat
{
    // TODO Move this to a DLL exported by a shared data project 
    // This is not avaliable yet in dotnetcore
    
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
