using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GeneralService.Comunicate.SocketClient
{
    using Models;
    public class SocketClient
    {
        public int port = 0;
        public string ismgIP = "";
        // ManualResetEvent instances signal completion.     
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        // The response from the remote device.     
        private static String response = String.Empty;

        private Socket Client = null;


        public void StartClient(out Socket socket)
        {
            if (port == 0 || ismgIP == "")
            {
                throw new NullReferenceException("端口号及IP地址不能为空");
                
            }
            //if(IPAddress.TryParse(ismgIP))
            try
            {
                IPAddress ismgIpAddress = IPAddress.Parse(ismgIP);
                IPEndPoint ismgEndPoint = new IPEndPoint(ismgIpAddress, port);

                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Client.BeginConnect(ismgEndPoint, new AsyncCallback(ConnectCallback),Client);
                connectDone.WaitOne();

                socket = Client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.     
                Socket client = (Socket)ar.AsyncState;
                // Complete the connection.     
                client.EndConnect(ar);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
                // Signal that the connection has been made.     
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Receive(Socket client)
        {
            try
            {
                // Create the state object.     
                 StateOject state = new StateOject();
                state.workSocket = client;
                // Begin receiving the data from the remote device.     
                client.BeginReceive(state.recieveBuffer, 0, StateOject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket     
                // from the asynchronous state object.     
                StateOject state = (StateOject)ar.AsyncState;
                Socket client = state.workSocket;
                // Read data from the remote device.     
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.     

                    state.recieveSB.Append(Encoding.ASCII.GetString(state.recieveBuffer, 0, bytesRead));
                    // Get the rest of the data.     
                    client.BeginReceive(state.recieveBuffer, 0, StateOject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.     
                    if (state.recieveSB.Length > 1)
                    {
                        response = state.recieveSB.ToString();
                    }
                    // Signal that all bytes have been received.     
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Send(Socket client, byte[] data)
        {
            // Convert the string data to byte data using ASCII encoding.     
            //byte[] byteData = Encoding.ASCII.GetBytes(data);
            // Begin sending the data to the remote device.     
            client.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.     
                Socket client = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device.     
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                // Signal that all bytes have been sent.     
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
