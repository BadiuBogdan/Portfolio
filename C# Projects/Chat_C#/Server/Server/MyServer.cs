using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class MyServer
    {
        private int portNumber = 8000;
        private bool isFirstMessage = true;
        private Dictionary<string, TcpClient> clientList;
        public MyServer()
        {
            clientList = new Dictionary<string, TcpClient>();
            Thread thread = new Thread(() => this.Run());
            thread.Start();
        }
        private void Run()
        {
            Console.WriteLine("Server running...");

            TcpListener serverSocket = new TcpListener(this.portNumber);
            serverSocket.Start();

            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                NetworkStream networkStream = clientSocket.GetStream();
                StreamReader streamReader = new StreamReader(networkStream);

                

                string identifier = null;
                string message = streamReader.ReadLine();
                if (message.Contains("!::user::!"))
                {
                    string[] temp = message.Split('!');
                    if (!clientList.ContainsKey(temp[0]))
                    {
                        clientList.Add(temp[0], clientSocket);
                        identifier = temp[0];
                    }

                }
                foreach (var i in clientList)
                {
                    foreach (var j in clientList)
                    {
                        if (!j.Key.Equals(i.Key))
                        {
                            SendMessage(j.Key + "!::cList::!", i.Key);
                        }
                        
                    }
                }
                Console.WriteLine("\n{0} has conected!\n", identifier);

                Thread thread = new Thread(() => this.ReceiveMessage(clientSocket, identifier));
                thread.Start();
            }
        }

        public void ReceiveMessage(TcpClient clientSocket, string identifire)
        {
            NetworkStream networkStream = clientSocket.GetStream();
            StreamReader streamReader = new StreamReader(networkStream);

            while (true)
            {

                string message = String.Empty;
                string sendMessage = String.Empty;
                try
                {
                    message = streamReader.ReadLine();
                    if (message!=null && message.Contains("!::text::!"))
                    {
                        string[] temp = message.Split('!');
                        sendMessage = identifire + ": " + temp[2];
                        SendMessage(sendMessage, temp[0]);
                    }
                }
                catch
                {
                    break;
                }

                if (message!= null && message.Equals("Stop!"))
                {
                    Console.WriteLine("\n{0} has disconnected!", identifire);
                    networkStream.Close();
                    clientSocket.Close();
                    clientList.Remove(identifire);
                    break;
                }

                if (this.isFirstMessage)
                {
                    Console.WriteLine("Here are the messages:");
                    this.isFirstMessage = false;
                }
                Console.WriteLine("{0}>> {1}", identifire, message);
            }
        }
        public void SendMessage(string message, string identifire)
        {
            NetworkStream networkStream = clientList[identifire].GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(message);
            streamWriter.Flush();
        }
        static public void Main(String[] args)
        {
            new MyServer();
        }
    }
}
