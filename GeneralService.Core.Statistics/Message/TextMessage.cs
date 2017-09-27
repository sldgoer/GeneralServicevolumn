using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Message
{
    using Interface;
    using Models;
    using Comunicate.SocketClient;
    public class TextMessage : ITextMessage
    {
        //const string ismg_Ip= "211.139.144.201";
        //const int port = 7890;
        //const string SP_Id = "999999";
        //const string Service_Id = "MGD0019900";
        //const string Src_Id = "106573401021";
        //const string SP_Account = "J01615";
        //const string SP_Secrect = "RMZVv%9U";
        #region CMPP Socket Package Object

        CMPP_CONNECT cmpp_connect = null;
        CMPP_CONNECT_RESP cmpp_connect_resp = null;
        CMPP_SUBMIT cmpp_submit = null;
        CMPP_SUBMIT_RESP cmpp_submit_resp = null;

        #endregion

        SocketClient sc = new SocketClient();
        //byte[] headerBytes;
        

        public CMPP_CONNECT_RESP ConnectToISMG(CMPP_CONNECT ConnectInfo)
        {
            sc.ismgIP = "211.139.144.201";
            sc.port = 7890;

            cmpp_connect = ConnectInfo;

            byte[] Total_Lenth = UintToByte(cmpp_connect.Total_Length, 4);
            byte[] Command_Id = UintToByte(cmpp_connect.Command_Id, 4);
            byte[] Sequence_Id = UintToByte(cmpp_connect.Sequence_Id, 4);

            byte[] Source_Addr = StringToOcet(cmpp_connect.Source_Addr, 6);
            byte[] AuthenticatorSource = cmpp_connect.AuthenticatorSource;
            byte[] Version = new byte[1];
            Version[0] = cmpp_connect.Version;
            byte[] Timestamp = UintToByte(cmpp_connect.Timestamp,4);

            List<byte[]> byteList = new List<byte[]>();
            byteList.Add(Total_Lenth);
            byteList.Add(Command_Id);
            byteList.Add(Sequence_Id);
            byteList.Add(Source_Addr);
            byteList.Add(AuthenticatorSource);
            byteList.Add(Version);
            byteList.Add(Timestamp);

            
            //cmpp_connect.            

            throw new NotImplementedException();
        }
        private CMPP_CONNECT_RESP ConnectToISMG(byte[] CMPP_CONNECT_BYTES)
        {

            throw new NotImplementedException();
        }

        public void BatchSend(List<string> MobileList, string Content)
        {
            throw new NotImplementedException();
        }

        object ITextMessage.Send(string Mobile, string Content)
        {

            throw new NotImplementedException();
        }

        object ITextMessage.Summary(DateTime Date)
        {
            throw new NotImplementedException();
        }

        object ITextMessage.SummaryByType(DateTime Date, string Service_Id)
        {
            throw new NotImplementedException();
        }
        

        private byte[] UintToByte(uint Value,int BufferSize)
        {
            byte[] buffer = new byte[BufferSize];
            byte[] tempbuffer = BitConverter.GetBytes(Value);
            Buffer.BlockCopy(tempbuffer, 0, buffer, 0, BufferSize);

            return buffer;

        }

        private byte[] StringToOcet(string Value, int BufferSize)
        {
            byte[] buffer = new byte[BufferSize];
            for (int i = 0; i < BufferSize; i++)
            {
                buffer[i] = 0x00;
            }

            byte[] tempbuffer = Encoding.ASCII.GetBytes(Value);
            Buffer.BlockCopy(tempbuffer, tempbuffer.Length - BufferSize, buffer, 0, BufferSize);

            return buffer;
        }
        
        private byte[] GetPackageBytes(List<byte[]> ByteList,int DestByteLen)
        {
            byte[] DestBytes = new byte[DestByteLen];

            int copy_index = 0;
            foreach(byte[] b in ByteList)
            {
                b.CopyTo(DestBytes, copy_index);
                copy_index += b.Length;
            }

            return DestBytes;
        }

        public enum CMPP_Command_Id : uint
        {
              CMPP_CONNECT = 0x00000001 //请求连接 
            , CMPP_CONNECT_RESP = 0x80000001 //请求连接应答 
            , CMPP_TERMINATE = 0x00000002 //终止连接 
            , CMPP_TERMINATE_RESP = 0x80000002 //终止连接应答 
            , CMPP_SUBMIT = 0x00000004 //提交短信 
            , CMPP_SUBMIT_RESP = 0x80000004 //提交短信应答 
            , CMPP_DELIVER = 0x00000005 //短信下发 
            , CMPP_DELIVER_RESP = 0x80000005 //下发短信应答 
            , CMPP_QUERY = 0x00000006 //发送短信状态查询 
            , CMPP_QUERY_RESP = 0x80000006 //发送短信状态查询应答 
            , CMPP_CANCEL = 0x00000007 //删除短信 
            , CMPP_CANCEL_RESP = 0x80000007 //删除短信应答 
            , CMPP_ACTIVE_TEST = 0x00000008 //激活测试 
            , CMPP_ACTIVE_TEST_RESP = 0x80000008 //激活测试应答 
            , CMPP_FWD = 0x00000009 //消息前转 
            , CMPP_FWD_RESP = 0x80000009 //消息前转应答 
            , CMPP_MT_ROUTE = 0x00000010 //MT路由请求 
            , CMPP_MT_ROUTE_RESP = 0x80000010 //MT路由请求应答 
            , CMPP_MO_ROUTE = 0x00000011 //MO路由请求 
            , CMPP_MO_ROUTE_RESP = 0x80000011 //MO路由请求应答 
            , CMPP_GET_MT_ROUTE = 0x00000012 //获取MT路由请求 
            , CMPP_GET_MT_ROUTE_RESP = 0x80000012 //获取MT路由请求应答 
            , CMPP_MT_ROUTE_UPDATE = 0x00000013 //MT路由更新 
            , CMPP_MT_ROUTE_UPDATE_RESP = 0x80000013 //MT路由更新应答 
            , CMPP_MO_ROUTE_UPDATE = 0x00000014 //MO路由更新 
            , CMPP_MO_ROUTE_UPDATE_RESP = 0x80000014 //MO路由更新应答 
            , CMPP_PUSH_MT_ROUTE_UPDATE = 0x00000015 //MT路由更新 
            , CMPP_PUSH_MT_ROUTE_UPDATE_RESP = 0x80000015 //MT路由更新应答 
            , CMPP_PUSH_MO_ROUTE_UPDATE = 0x00000016 //MO路由更新 
            , CMPP_PUSH_MO_ROUTE_UPDATE_RESP = 0x80000016 //MO路由更新应答 
            , CMPP_GET_MO_ROUTE = 0x00000017 //获取MO路由请求 
            , CMPP_GET_MO_ROUTE_RESP = 0x80000017 //获取MO路由请求应答 
        }
    }
}
