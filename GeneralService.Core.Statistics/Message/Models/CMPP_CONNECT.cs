using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Message.Models
{
    public class CMPP_CONNECT : MsgBase
    {
        //源地址，此处为SP_Id，即SP的企业代码。
        public byte[] Source_Addr;

        //用于鉴别源地址。其值通过单向MD5 hash计算得出，表示如下：
        //AuthenticatorSource =
        //MD5（Source_Addr+9 字节的0 +shared secret+timestamp）
        //Shared secret 由中国移动与源地址实体事先商定，timestamp格式为：MMDDHHMMSS，即月日时分秒，10位。
        public byte[] AuthenticatorSource;

        //双方协商的版本号(高位4bit表示主版本号,低位4bit表示次版本号)
        public byte Version;        

        //时间戳的明文,由客户端产生,格式为MMDDHHMMSS，即月日时分秒，10位数字的整型，右对齐 。
        public uint Timestamp;

    }
}
