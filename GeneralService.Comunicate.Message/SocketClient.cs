using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace GeneralService.Comunicate.SocketClient
{
    using Models;
    public class SClient
    {
        public int port = 0;
        public string ismgIP = "";
        // ManualResetEvent instances signal completion.     
        //private static ManualResetEvent connectDone = new ManualResetEvent(false);
        //private static ManualResetEvent sendDone = new ManualResetEvent(false);
        //private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        // The response from the remote device.     
        //private readonly object locker = new object();

        private static List<byte[]> response;

        private Socket Client = null;
        private GeneralService.Utility.ByteUtility.BytesHandler bh = new Utility.ByteUtility.BytesHandler();

        #region 事件定义
        public delegate void Sockect_OkEventHandler(object sender, EventArgs e);
        public event EventHandler<SocketClientEventArgs> Socket_OK;

        public delegate void Package_SentEventHandler(object sender, EventArgs e);
        public event EventHandler<SocketClientEventArgs> Package_Sent;

        public delegate void Package_RecievedHandler(object sender, EventArgs e);
        public event EventHandler<SocketClientEventArgs> Package_Recieved;
        #endregion



        public void StartClient()
        {
            if (port == 0 || ismgIP == "")
            {
                throw new NullReferenceException("端口号及IP地址不能为空");

            }

            lock (this)
            {
                try
                {
                    IPAddress ismgIpAddress = IPAddress.Parse(ismgIP);
                    IPEndPoint ismgEndPoint = new IPEndPoint(ismgIpAddress, port);

                    Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    Client.BeginConnect(ismgEndPoint, IAsyncResult =>
                    {
                        Socket client = (Socket)IAsyncResult.AsyncState;

                        Console.WriteLine("Server is connected!!!");
                        Console.WriteLine("Connected:" + client.Connected);

                        SocketClientEventArgs e = new SocketClientEventArgs();
                        e.Feeckback = new byte[1] { 0 };
                        Socket_OK(this, e);

                    }, Client);
                    //connectDone.WaitOne();

                    


                    //socket = Client;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public Socket GetCurrentSocket()
        {
            return this.Client;
        }

        public List<byte[]> GetRecievedData()
        {
            return response;
        }

        //private void ConnectCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        // Retrieve the socket from the state object.     
        //        Client = (Socket)ar.AsyncState;
        //        // Complete the connection.     
        //        //Client.EndConnect(ar);
        //        //Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
        //        // Signal that the connection has been made.     
        //        //connectDone.Set();

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public void Receive()
        {
            try
            {
                //Console.WriteLine("1");
                // Create the state object.     
                StateOject state = new StateOject();
                state.workSocket = Client;
                // Begin receiving the data from the remote device.   

                Console.WriteLine("Begin to recieve data!!!");  
                Client.BeginReceive(state.recieveBuffer, 0, StateOject.BufferSize, 0, IAsyncResult=> {
                    Console.WriteLine("Data recieved!!!Length:" + Client.Available);
                    Console.WriteLine("MSG len:" + BitConverter.ToUInt32(state.recieveBuffer, 0));

                    if (state.recieveBuffer.Length > 0)
                    {
                        SocketClientEventArgs e = new SocketClientEventArgs();
                        e.Feeckback = state.recieveBuffer;
                        Package_Recieved(this, e);
                    }                    

                    Receive();
                }, state);               
                
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                throw e;
            }
        }

        //private void ReceiveCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        // Retrieve the state object and the client socket     
        //        // from the asynchronous state object.     
        //        StateOject state = (StateOject)ar.AsyncState;
        //        Socket client = state.workSocket;
        //        // Read data from the remote device.     
        //        int bytesRead = client.EndReceive(ar);
        //        if (bytesRead > 0)
        //        {
        //            // There might be more data, so store the data received so far.     
        //            state.recieveBytes.Add(state.recieveBuffer);
        //            //state.recieveSB.Append(Encoding.ASCII.GetString(state.recieveBuffer, 0, bytesRead));
        //            // Get the rest of the data.     
        //            client.BeginReceive(state.recieveBuffer, 0, StateOject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
        //        }
        //        else
        //        {
        //            // All the data has arrived; put it in response.     
        //            if (state.recieveBytes.Count > 1)
        //            {
        //                response = state.recieveBytes;
        //            }
        //            // Signal that all bytes have been received.     
        //            //receiveDone.Set();

        //            //SocketClientEventArgs e = new SocketClientEventArgs();
        //            //e.Feeckback = response;
        //            //Package_Sent(this, e);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}

        public void Send( byte[] data)
        {
            // Convert the string data to byte data using ASCII encoding.     
            //byte[] byteData = Encoding.ASCII.GetBytes(data);
            // Begin sending the data to the remote device.
            Console.WriteLine("Begin to send data!!!");

            if (Client == null) { throw new NullReferenceException("Socket has not connected!!!"); }   
            
            Client.BeginSend(data, 0, data.Length, 0, IAsyncResult=> {
                Console.WriteLine("MSG has sent!!!");

                SocketClientEventArgs e = new SocketClientEventArgs();
                e.Feeckback = new byte[1] { 0 };
                Package_Sent(this, e);

                Receive();

            }, Client);

            //sendDone.WaitOne();

            

            //Receive(client);
        }

        //private void SendCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        // Retrieve the socket from the state object.     
        //        Socket client = (Socket)ar.AsyncState;
        //        // Complete sending the data to the remote device.     
        //        int bytesSent = client.EndSend(ar);
        //        Console.WriteLine("Sent {0} bytes to server.", bytesSent);
        //        // Signal that all bytes have been sent.     
        //        //sendDone.Set();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}

        
    }
}
