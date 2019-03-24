using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.Interaction
{
    public class RemoteInteract : Interact
    {
        public override bool IsRunning { get { return client == null ? false : client.Connected; } } 

        private TcpClient client { get; set; }
        public string HostName { get; private set; }
        public int Port { get; private set; }

        public RemoteInteract(string hostname, int port)
        {
            HostName = hostname;
            Port = port;
        }

        public override void Start()
        {
            client = new TcpClient(HostName, Port);
            MainStream = client.GetStream();
        }

        public override void Stop()
        {

        }
    }
}
