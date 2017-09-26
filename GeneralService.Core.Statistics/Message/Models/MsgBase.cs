using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Message.Models
{
    public class MsgBase
    {
        byte[] MsgByte = null;

        public uint Total_Length = 0x0;
        public uint Command_Id = 0x0;
        public uint Sequence_Id = 0x0;

    }
}
