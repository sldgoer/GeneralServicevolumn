using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Comunicate.Message.Models.MessageModels
{
    public class MsgHeader
    {
        //public uint Total_Length { get; set; }
        //public uint Command_Id { get; set; }
        //public uint Sequence_Id { get; set; }

        //public byte[] GetHeaderByte()
        //{
        //    //Codes
        //    return null;
        //}

        private List<MsgPiece> headerPieces = new List<MsgPiece>();
        public List<MsgPiece> _headerPieces
        {
            get { return headerPieces; }
            set { headerPieces = value; }
        }

        public MsgHeader(List<MsgPiece> HeaderPieces)
        {
            headerPieces = HeaderPieces;
        }

        public List<MsgPiece> GetHeader()
        {
            return _headerPieces;
        }

        public int GetHeaderLen()
        {
            int len = 0;
            foreach(MsgPiece mp in headerPieces)
            {
                len += mp.ByteLen;
            }

            return len;
        }
    }
}
