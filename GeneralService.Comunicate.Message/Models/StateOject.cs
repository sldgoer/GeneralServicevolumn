using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GeneralService.Comunicate.SocketClient.Models
{
    public class StateOject
    {
        public Socket workSocket = null;
        public const int BufferSize = 256;
        public byte[] recieveBuffer = new byte[BufferSize];
        public StringBuilder recieveSB = new StringBuilder();
    }
}
