using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Message.Models
{
    public class CMPP_CONNECT_RESP : MsgBase
    {
        //状态
        //0：正确
        //1：消息结构错
        //2：非法源地址
        //3：认证错
        //4：版本太高
        //5~ ：其他错误
        public uint Status;

        //ISMG认证码，用于鉴别ISMG。
        //其值通过单向MD5 hash计算得出，表示如下：
        //AuthenticatorISMG =MD5（Status+AuthenticatorSource+shared secret），Shared secret 由中国移动与源地址实体事先商定，AuthenticatorSource为源地址实体发送给ISMG的对应消息CMPP_Connect中的值。
        //认证出错时，此项为空。
        public string AuthenticatorISMG;

        //服务器支持的最高版本号
        public uint Version;
    }
}
