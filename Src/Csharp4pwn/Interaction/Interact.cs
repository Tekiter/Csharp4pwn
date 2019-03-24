using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.Interaction
{
    public abstract class Interact
    {
        public abstract bool IsRunning { get; }
        public abstract void Start();
        public abstract void Stop();


        protected Stream MainStream { get; set; }

        public Encoding Encoding { get; set; } = Encoding.UTF8;


        public Stream GetStream()
        {
            return MainStream;
        }


        public string Recv(int length)
        {
            
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (true)
            {
                if (i == length)
                {
                    break;
                }
                sb.Append(Convert.ToChar(MainStream.ReadByte()));
                i++;
            }
            return sb.ToString();
        }

        public string RecvUntil(string stop)
        {
            string sb = "";
            while (true)
            {

                sb += Convert.ToChar(MainStream.ReadByte());
                if (sb.EndsWith(stop))
                {
                    break;
                }

            }

            return sb;
        }

        public string RecvLine()
        {
            return RecvUntil("\n");
        }

        public string RecvLineAfter(string waitstr)
        {
            RecvUntil(waitstr);
            return RecvLine();
        }

        public void Send(string str)
        {
            byte[] buf = Encoding.UTF8.GetBytes(str);
            MainStream.Write(buf, 0, buf.Length);
        }

        public void SendLine(string str)
        {
            Send(str + "\n");
        }

        public void SendLineAfter(string waitstr, string str)
        {
            RecvUntil(waitstr);
            SendLine(str);
        }

    }
}
