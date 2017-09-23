using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GeneralService.Comunicate.Message
{
    using Models;
    class TextMessage
    {
        public string ismgIP { get; set; }
        public int port { get; set; }

        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);
        // The response from the remote device.     
        private String response = String.Empty;

        private void StartClient()
        {
            try
            {
                IPAddress ismgIpAddress = IPAddress.Parse(ismgIP);
                IPEndPoint ismgEndPoint = new IPEndPoint(ismgIpAddress, port);

                Socket ispClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //ispClient.BeginConnect(ismgEndPoint,new AsyncCallback())
            }
            catch (Exception ex)
            {

            }
        }
    }
}
