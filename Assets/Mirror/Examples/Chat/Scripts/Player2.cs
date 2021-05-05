using System;
using UnityEngine;



namespace NetworkingTutorial.Assets.Mirror.Examples.Chat.Scripts
{
    public class Player2 : MonoBehaviour
    {
        [SyncVar]
        public string playerName; 

        public static event Action<Player2, string> OnMessage; //

        [Common]
        public void CmdSend(string message)
        {
            if(message.Trim() != "")
                RpcReceive(message.Trim());

        }
        [ClientRpc]
        public void RpcReceive(string message)
        {
            OnMessage?.Invoke(this, message);
        }
    }
}