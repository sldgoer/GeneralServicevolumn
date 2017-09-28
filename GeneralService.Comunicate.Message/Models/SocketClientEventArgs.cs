using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Comunicate.SocketClient.Models
{
    public class SocketClientEventArgs:EventArgs
    {
        public byte[] Feeckback
        {
            get;set;
        }
    }
}
