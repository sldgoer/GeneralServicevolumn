using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Comunicate.Message.Models.MessageModels
{
    public class MsgPiece
    {
        public string Name { get; set; }
        public int ByteLen { get; set; }
        public char FillChar { get; set; }
        public FillSide fillSide { get; set; }        

        public enum FillSide
        {
            Left,
            Right
        }

    }
}
