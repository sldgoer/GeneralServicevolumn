using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Message.Models
{
    public class MsgSubmitPackage
    {
        public byte[] MsgId_Byte {
            get{
                return new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            }
        }
        public byte[] Pktotal_Byte = new byte[1];
        public byte[] Pknumber_Byte = new byte[1];
        public byte[] RegisteredDelivery_Byte = new byte[1];
        public byte[] MsglevelLevel_Byte = new byte[1];
        public byte[] ServiceId_Byte = new byte[10];
        public byte[] FeeUserType_Byte = new byte[1];
        public byte[] FeeterminalId_Byte = new byte[21];
        public byte[] TPpId_Byte = new byte[1];
        public byte[] TPudhi_Byte = new byte[1];
        public byte[] MsgFmt_Byte = new byte[1];
        public byte[] Msgsrc_Byte = new byte[6];
        public byte[] FeeType_Byte = new byte[2];
        public byte[] FeeCode_Byte = new byte[6];
        public byte[] ValIdTime_Byte = new byte[17];
        public byte[] AtTime_Byte = new byte[17];
        public byte[] SrcId_Byte = new byte[21];
        public byte[] DestUsrtl_Byte = new byte[1];
        public byte[] DestterminalId = new byte[21];
        public byte[] MsgLength_Byte = new byte[1];
        public byte[] MsgContent_Byte;
        public byte[] Reserve = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
    }
}
