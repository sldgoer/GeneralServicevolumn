using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Comunicate.Message.Models.MessageModels
{
    public class MsgBody
    {
        private List<MsgPiece> bodyPieces = new List<MsgPiece>();
        public List<MsgPiece> _bodyPieces
        {
            get { return bodyPieces; }
            set { bodyPieces = value; }
        }

        public MsgBody(List<MsgPiece> MsgPieces)
        {
            bodyPieces = MsgPieces;
        }

        public List<MsgPiece> GetBody()
        {
            return _bodyPieces;
        }
        public int GetBodyLen()
        {
            int len = 0;
            foreach (MsgPiece mp in bodyPieces)
            {
                len += mp.ByteLen;
            }

            return len;
        }
        //public byte[] GetBodyByte()
        //{
        //    //Codes
        //    return null;
        //}
    }
}
