﻿using MagicalLifeClient.Processing;
using MagicalLifeNetworkMessages;
using MagicalLifeNetworkMessages.Messages;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient.Networking
{
    /// <summary>
    /// The TCP client for communicating with the server.
    /// </summary>
    public class TCPClient
    {
        public SimpleTcpClient Client;

        public void Start(int port, string ip = "192.168.0.14")
        {
            ClientProcessor.Initialize();
            this.Client = new SimpleTcpClient();
            this.Client.DataReceived += this.Client_DataReceived;

            this.Client.Connect(ip, port);
        }

        private void Client_DataReceived(object sender, Message e)
        {
            NetworkMessage msg = (NetworkMessage)JsonUtil.Deserialize(e.MessageString);
            ClientProcessor.Process(msg);
        }
    }
}
