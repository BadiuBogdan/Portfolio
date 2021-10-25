using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat
{
    public class MyClient
    {
        private int portNumber = 8000;
        private TcpClient clientSocket = null;
        private NetworkStream networkStream = null;
        private StreamWriter streamWriter = null;
        private StreamReader streamReader= null;

        private string message;
        public string Message { get => message; set => message = value; }
        public StreamReader StreamReader { get => streamReader; set => streamReader = value; }

        public MyClient()
        {
            this.clientSocket = new TcpClient("localhost", this.portNumber);
            this.networkStream = this.clientSocket.GetStream();
            this.streamWriter = new StreamWriter(this.networkStream);
            this.streamReader = new StreamReader(this.networkStream);


        }
       public void ReceiveMessage(out string stringOut)
        {
            stringOut = String.Empty;
            while (true)
            {

                string message = String.Empty;

                try
                {
                    message = streamReader.ReadLine();
                    Console.WriteLine(message);
                    if (message.Equals("Stop!"))
                    {
                        stringOut = message;
                        break;
                    }
                   stringOut=message;
                }
                catch
                {
                    break;
                }

            }
        }
        public void SendMessage(string message)
        {

                this.streamWriter.WriteLine(message);
                this.streamWriter.Flush();
        }
    }
}
