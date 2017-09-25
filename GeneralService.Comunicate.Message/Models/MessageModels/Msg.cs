using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Comunicate.Message.Models.MessageModels
{
    public class Msg
    {
        private MsgHeader msgheader;
        private MsgBody msgbody;

        public Msg(MsgHeader msgHeader,MsgBody msgBody)
        {
            msgheader = msgHeader;
            msgbody = msgBody;
        }

        public byte[] GetMsgByte()
        {
            int TotalLen = msgheader.GetHeaderLen() + msgbody.GetBodyLen();
            byte[] buff = new byte[TotalLen];
                                    
            foreach(MsgPiece mp in msgheader.GetHeader())
            {

            }

            return null;
        }

        //private string AutoFill(String Value,char FillChar,MsgPiece.FillSide fillSide,int Len)
        //{
        //    StringBuilder sb = new StringBuilder();
            
        //}
    }
}
