using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Message.Models
{
    public class CMPP_SUBMIT : MsgBase
    {
        //8 bytes 
        public uint Msg_Id;

        //1 byte 相同Msg_Id的信息总条数，从1开始
        public uint Pk_total;

        //相同Msg_Id的信息序号，从1开始
        public uint Pk_number;

        //是否要求返回状态确认报告：
        //0：不需要
        //1：需要
        //2：产生SMC话单
        // （该类型短信仅供网关计费使用，不发送给目的终端)
        public uint Registered_Delivery;

        //信息级别
        public uint Msg_level;

        //业务类型，是数字、字母和符号的组合。
        public byte[] Service_Id;

        //计费用户类型字段
        //0：对目的终端MSISDN计费；
        //1：对源终端MSISDN计费；
        //2：对SP计费;
        //3：表示本字段无效，对谁计费参见Fee_terminal_Id字段。
        public uint Fee_UserType;
        
        // 被计费用户的号码（如本字节填空，则表示本字段无效，对谁计费参见Fee_UserType字段，本字段与Fee_UserType字段互斥）
        public uint Fee_terminal_Id;

        //GSM协议类型。详细是解释请参考GSM03.40中的9.2.3.9
        public uint TP_pId;

        //GSM协议类型。详细是解释请参考GSM03.40中的9.2.3.23,仅使用1位，右对齐
        public uint TP_udhi;

        //信息格式
        //0：ASCII串
        //3：短信写卡操作
        //4：二进制信息
        //8：UCS2编码
        //15：含GB汉字  。。。。。。 
        public uint Msg_Fmt;

        //信息内容来源(SP_Id)
        public byte[] Msg_src;

        //资费类别
        //01：对“计费用户号码”免费
        //02：对“计费用户号码”按条计信息费
        //03：对“计费用户号码”按包月收取信息费
        //04：对“计费用户号码”的信息费封顶
        //05：对“计费用户号码”的收费是由SP实现
        public byte[] FeeType;

        //资费代码（以分为单位）
        public byte[] FeeCode;

        //存活有效期，格式遵循SMPP3.3协议
        public byte[] ValId_Time;

        //定时发送时间，格式遵循SMPP3.3协议
        public byte[] At_Time;

        //源号码
        //SP的服务代码或前缀为服务代码的长号码, 网关将该号码完整的填到SMPP协议Submit_SM消息相应的source_addr字段，该号码最终在用户手机上显示为短消息的主叫号码
        public byte[] Src_Id;

        //接收信息的用户数量(小于100个用户)
        public uint DestUsr_tl;

        //接收短信的MSISDN号码
        public byte[] Dest_terminal_Id;

        //信息长度(Msg_Fmt值为0时：<160个字节；其它<=140个字节)
        public uint Msg_Length;

        //信息内容
        public byte[] Msg_Content;

        //保留
        public byte[] Reserve;

    }
}
