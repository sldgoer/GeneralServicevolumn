using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Message.Models
{
    public class ISMGEventArgs:EventArgs
    {
        public int Result;
        public string Message;
    }
}
