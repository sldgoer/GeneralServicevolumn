using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Message
{
    using Comunicate.SocketClient;
    using Comunicate.SocketClient.Models;
    using Utility.ByteUtility;
    using Models;
    public class TextMessage
    {
        #region 参考信息
        //服务代码106573401021

        //企业代码999999

        //业务代码MGD0019900

        //登录网关帐号名称J01615

        //登录网关密码RMZVv%9U(似乎没用)

        //网关IP地址211.139.144.201

        //网关服务端口号7890
        #endregion

        #region 通用参数
        public string Service_Id { get; private set; }
        public string Corp_Id { get; private set; }
        public string Business_Id { get; private set; }
        public string SP_Id { get; private set; }
        public string Secret { get; private set; }
        public string CMPP_Version { get; private set; }
        public string Ip = "";
        public int Port = 0;
        //public byte[] AuthenticatorSource { get; private set; }
        const int CMPP_CONNECT_Len = 39;
        const int CMPP_CONNECT_RESP_Len = 30;
        const int CMPP_TERMINATE_Len = 0;
        const int CMPP_TERMINATE_RESP_Len = 0;

        #endregion

        static int nFlag = 0;  // 0：空闲；    1：Socket已连接；    2：已向ISMG注册

        #region 事件定义
        public delegate void Socket_ConnectedEventHandler(object sender, ISMGEventArgs e);
        public event EventHandler<ISMGEventArgs> Socket_Connected;

        public delegate void ISMG_RegistedEventHandler(object sender, ISMGEventArgs e);
        public event EventHandler<ISMGEventArgs> ISMG_Registed;

        public delegate void ISMG_MessageSubmittedEventHandler(object sender, ISMGEventArgs e);
        public event EventHandler<ISMGEventArgs> ISMG_MessageSubmitted;

        //public delegate void ISMG_Message
        #endregion

        private SClient sc = new SClient();
        private BytesHandler bh = new BytesHandler();

        delegate void ResponseHandler(byte[] bytes);
        
        public TextMessage(string service_id,string corp_id,string business_id,string sp_id,string secret,string cmpp_version,string ip,int port)
        {
            Service_Id = service_id;
            Corp_Id = corp_id;
            Business_Id = business_id;            
            SP_Id = sp_id;
            Secret = secret;
            CMPP_Version = cmpp_version;
            Ip = ip;
            Port = port;

            InitialSocket();                                 
       
        }

        #region 公共函数

        public void RegisterToISMG()
        {
            if (nFlag == 1)
            {
                Console.WriteLine("Begin to Register!!!");
                //DateTime now = DateTime.Now;
                byte[] bHeader = GetHeaderBytes(CMPP_CONNECT_Len, Service_Command_Id.CMPP_CONNECT);
                byte[] bSource_Addr = new byte[6];
                byte[] bAuthenticatorSource = new byte[16];
                byte[] bVersion = new byte[1];
                byte[] bTimestamp = new byte[4];

                bSource_Addr= Encoding.ASCII.GetBytes(SP_Id);
                //bh.GetBytesFromString(SP_Id, ref bSource_Addr, '\0', BytesHandler.CoverSide.Left);
                var timeStamp = GetTimeStamp(DateTime.Now);
                bTimestamp = BitConverter.GetBytes(Convert.ToUInt32(timeStamp));
                Array.Reverse(bTimestamp);

                bVersion[0] = GetVersionByte(CMPP_Version);
                bAuthenticatorSource = GetAuthenticatorSource(SP_Id, Secret, timeStamp);

                //For test
                //PrintBytes(bHeader);
                //PrintBytes(bSource_Addr);
                //PrintBytes(bAuthenticatorSource);
                //PrintBytes(bVersion);
                //PrintBytes(bTimestamp);

                //Console.WriteLine(String.Format("{0}",bAuthenticatorSource));

                List<byte[]> bytelist = new List<byte[]>();
                bytelist.Add(bHeader);
                bytelist.Add(bSource_Addr);
                bytelist.Add(bAuthenticatorSource);
                bytelist.Add(bVersion);
                bytelist.Add(bTimestamp);

                byte[] regbytes = new byte[CMPP_CONNECT_Len];
                bh.BytesCombine(bytelist, ref regbytes);

                //string h = "";
                
                //sc.Receive(sc.GetCurrentSocket());
                sc.Send(regbytes);

                //Console.WriteLine(sc.GetCurrentSocket().Connected);

                sc.Receive();
               

            }
            else if (nFlag == 0)
            {
                throw new Exception("Socket未连接，请检查网络连接！");
            }
            else if (nFlag == 2)
            {
                return;
            }

        }

        public void SendMessageToSingleMobile(string mobile,string content)
        {
            #region 字段定义
            byte[] MsgId_Byte = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            byte[] Pktotal_Byte = new byte[1];
            byte[] Pknumber_Byte = new byte[1];
            byte[] RegisteredDelivery_Byte = new byte[1];
            byte[] MsgLevel_Byte = new byte[1];
            byte[] ServiceId_Byte = new byte[10];
            byte[] FeeUserType_Byte = new byte[1];
            byte[] FeeterminalId_Byte = new byte[21];
            byte[] TPpId_Byte = new byte[1];
            byte[] TPudhi_Byte = new byte[1];
            byte[] MsgFmt_Byte = new byte[1];
            byte[] Msgsrc_Byte = new byte[6];
            byte[] FeeType_Byte = new byte[2];
            byte[] FeeCode_Byte = new byte[6];
            byte[] ValIdTime_Byte = new byte[17];
            byte[] AtTime_Byte = new byte[17];
            byte[] SrcId_Byte = new byte[21];
            byte[] DestUsrtl_Byte = new byte[1];
            byte[] DestterminalId = new byte[21];
            byte[] MsgLength_Byte = new byte[1];
            byte[] MsgContent_Byte = null;
            byte[] Reserve_Byte = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            #endregion

            #region 字段赋值
            //MsgSubmitPackage msp = new MsgSubmitPackage();
            Pktotal_Byte = BitConverter.GetBytes(1);
            Array.Reverse(Pktotal_Byte);
                  
            Pknumber_Byte = BitConverter.GetBytes(1);
            Array.Reverse(Pknumber_Byte);

            RegisteredDelivery_Byte = BitConverter.GetBytes(1);
            Array.Reverse(RegisteredDelivery_Byte);

            MsgLevel_Byte = BitConverter.GetBytes(1);
            Array.Reverse(MsgLevel_Byte);

            ServiceId_Byte = Encoding.ASCII.GetBytes(Business_Id);

            FeeUserType_Byte = BitConverter.GetBytes(2);
            Array.Reverse(FeeUserType_Byte);

            //msp.FeeterminalId_Byte

            TPpId_Byte = BitConverter.GetBytes(1);
            Array.Reverse(TPpId_Byte);

            TPudhi_Byte = BitConverter.GetBytes(0);
            Array.Reverse(TPudhi_Byte);

            MsgFmt_Byte = BitConverter.GetBytes(8);
            Array.Reverse(MsgFmt_Byte);

            Msgsrc_Byte = Encoding.ASCII.GetBytes(SP_Id);
            FeeType_Byte = Encoding.ASCII.GetBytes("03");
            FeeCode_Byte = Encoding.ASCII.GetBytes("099");
            ValIdTime_Byte = Encoding.ASCII.GetBytes(getValIdTime());
            AtTime_Byte = Encoding.ASCII.GetBytes(getAtTime(DateTime.Now));
            SrcId_Byte = Encoding.ASCII.GetBytes("000000000106573401021");

            DestUsrtl_Byte = BitConverter.GetBytes(1);
            Array.Reverse(DestUsrtl_Byte);

            DestterminalId = Encoding.ASCII.GetBytes("0000000000" + mobile);

            //MsgLength_Byte = BitConverter.GetBytes(Encoding.Unicode.GetBytes(content).Length);
            //Array.Reverse(MsgLength_Byte);
            //MsgContent_Byte = Encoding.Unicode.GetBytes(content);

            MsgContent_Byte = Encoding.Unicode.GetBytes(content);

            if (MsgContent_Byte.Length <= 140)
            {
                MsgLength_Byte = BitConverter.GetBytes(MsgContent_Byte.Length);
                Array.Reverse(MsgLength_Byte);
            }
            else { return -1; }

            #endregion

            #region 数据组包
            int totalLen = 12 +MsgId_Byte.Length+ Pktotal_Byte.Length + Pknumber_Byte.Length + RegisteredDelivery_Byte.Length + MsgLevel_Byte.Length + ServiceId_Byte.Length + FeeUserType_Byte.Length + FeeterminalId_Byte.Length + TPpId_Byte.Length + TPudhi_Byte.Length + MsgFmt_Byte.Length + Msgsrc_Byte.Length + FeeType_Byte.Length + FeeCode_Byte.Length + ValIdTime_Byte.Length + AtTime_Byte.Length + SrcId_Byte.Length + DestUsrtl_Byte.Length + DestterminalId.Length + MsgLength_Byte.Length + MsgContent_Byte.Length + Reserve_Byte.Length;
            byte[] submitbytes = new byte[totalLen];
            byte[] bHeader = GetHeaderBytes(totalLen, Service_Command_Id.CMPP_SUBMIT);

            List<byte[]> byteList = new List<byte[]>();
            byteList.Add(bHeader);
            byteList.Add(MsgId_Byte);
            byteList.Add(Pktotal_Byte);
            byteList.Add(Pknumber_Byte);
            byteList.Add(RegisteredDelivery_Byte);
            byteList.Add(MsgLevel_Byte);
            byteList.Add(ServiceId_Byte);
            byteList.Add(FeeUserType_Byte);
            byteList.Add(FeeterminalId_Byte);
            byteList.Add(TPpId_Byte);
            byteList.Add(TPudhi_Byte);
            byteList.Add(MsgFmt_Byte);
            byteList.Add(Msgsrc_Byte);
            byteList.Add(FeeType_Byte);
            byteList.Add(FeeCode_Byte);
            byteList.Add(ValIdTime_Byte);
            byteList.Add(AtTime_Byte);
            byteList.Add(SrcId_Byte);
            byteList.Add(DestUsrtl_Byte);
            byteList.Add(DestterminalId);
            byteList.Add(MsgLength_Byte);
            byteList.Add(MsgContent_Byte);
            byteList.Add(Reserve_Byte);
            #endregion

            bh.BytesCombine(byteList, ref submitbytes);

            sc.Send(submitbytes);

            sc.Receive();
            //MsgSubmitPackage msp = new MsgSubmitPackage();

            //msp.

        }

        public void SendMessage(List<string> mobilenumbers,string content)
        {
            int mobileCount = mobilenumbers.Count;


        }

        #endregion

        private void InitialSocket()
        {
            //SocketClient sc = new SocketClient();
            sc.Socket_OK += new EventHandler<SocketClientEventArgs>(SocketOKEventHandler);
            sc.Package_Sent += new EventHandler<SocketClientEventArgs>(PackageSentEventHandler);
            sc.Package_Recieved += new EventHandler<SocketClientEventArgs>(PackageRecievedEventHandler);
            sc.ismgIP = Ip;
            sc.port = Port;
            sc.StartClient();
        }

        #region 事件处理函数

        private void SocketOKEventHandler(object sender,SocketClientEventArgs e)
        {
            nFlag = 1;
            //Console.WriteLine("Socket is OK!");
            ISMGEventArgs ismgER = new ISMGEventArgs();
            ismgER.Result = 0;
            ismgER.Message = "Sockcet is OK!!";

            Socket_Connected(this, ismgER);

        }

        private void PackageSentEventHandler(object sender,SocketClientEventArgs e)
        {
            ISMGEventArgs ismgER = new ISMGEventArgs();
            ismgER.Result = 0;
            ismgER.Message = "Package has sent!!";
            


            Console.WriteLine("Package has sent!");
        }

        private void PackageRecievedEventHandler(object sender,SocketClientEventArgs e)
        {
            ResponseHandler rsh;

            PrintBytes(e.Feeckback);

            byte[] PackageLen_Buffer = new byte[4];
            byte[] CommandId_Buffer = new byte[4];

            Buffer.BlockCopy(e.Feeckback, 0, PackageLen_Buffer,0, 4);
            Buffer.BlockCopy(e.Feeckback, 4, CommandId_Buffer, 0, 4);
            Array.Reverse(CommandId_Buffer);

            UInt32 CommandId = BitConverter.ToUInt32(CommandId_Buffer,0);
            UInt32 PackageLen = BitConverter.ToUInt32(PackageLen_Buffer, 0);
                       

            switch (CommandId)
            {
                //Register response
                case 0x80000001:
                    rsh = new ResponseHandler(RegisterResponse);
                    rsh.Invoke(e.Feeckback);
                    break;
                //Terminate response
                case 0x80000002:
                    rsh = new ResponseHandler(SubmitResponse);
                    rsh.Invoke(e.Feeckback);
                    break;
                //Sumit message response
                case 0x80000004:
                    break;
            }

        }

        #endregion

        #region Functions after ISMG response 

        private void RegisterResponse(byte[] responseBytes)
        {
            byte[] StatusByte = new byte[2];
            byte[] AuthenticatorISMGByte = new byte[16];
            byte[] VersionByte = new byte[2];

            Buffer.BlockCopy(responseBytes, 12, StatusByte, 1, 1);
            Buffer.BlockCopy(responseBytes, 13, AuthenticatorISMGByte, 0, 16);
            Buffer.BlockCopy(responseBytes, 29, VersionByte, 1, 1);

            int Status = BitConverter.ToInt16(StatusByte, 0);
            StringBuilder AuthenticatorISMGBuilder = new StringBuilder();
            for(int i = 0; i < AuthenticatorISMGByte.Length; i++)
            {
                string s = String.Format("{0:X000}" + "-", AuthenticatorISMGByte[i]);
                //Console.WriteLine(s);
                AuthenticatorISMGBuilder.Append(s);
            }

            ISMGEventArgs iea = new ISMGEventArgs();
            iea.Result = Status;
            iea.Message = AuthenticatorISMGBuilder.ToString();

            ISMG_Registed.Invoke(this, iea);

        }

        private void SubmitResponse(byte[] responseBytes)
        {
            byte[] MsgIdByte = new byte[8];
            byte[] ResultByte = new byte[2];

            Buffer.BlockCopy(responseBytes, 12, MsgIdByte, 0, 8);
            Buffer.BlockCopy(responseBytes, 20, ResultByte, 1, 1);

            int Result = BitConverter.ToInt16(ResultByte, 0);
            StringBuilder MsgIdBuilder = new StringBuilder();
            for(int i = 0; i < MsgIdByte.Length; i++)
            {
                MsgIdBuilder.Append(String.Format("{ 0:X000 }" + "-", MsgIdByte[i]));
            }

            ISMGEventArgs iea = new ISMGEventArgs();
            iea.Result = Result;
            iea.Message = MsgIdBuilder.ToString();

            ISMG_MessageSubmitted.Invoke(this, iea);

        }

        #endregion

        #region 私有函数

        private byte GetVersionByte(string versionString)
        {
            var s = versionString.Split('.');
            uint highBit = uint.Parse(s[0])<<4;
            uint lowBit = uint.Parse(s[1]);
                        
            var result = (byte)(highBit | lowBit);

            return result;
        }
                
        private byte[] GetAuthenticatorSource(string Src_Addr,string secret,string timestamp)
        {
            if (timestamp.Length == 9) { timestamp = "0" + timestamp; }

            byte[] byteSrcAddr = Encoding.ASCII.GetBytes(Src_Addr);
            byte[] nineZero = new byte[] { 0X0, 0X0, 0X0, 0X0, 0X0, 0X0, 0X0, 0X0, 0X0 };
            byte[] byteSecret = Encoding.ASCII.GetBytes(secret);
            byte[] byteTimestamp = Encoding.ASCII.GetBytes(timestamp);

            //PrintBytes(nineZero);          

            byte[] auSrc = new byte[byteSrcAddr.Length + nineZero.Length + byteSecret.Length + byteTimestamp.Length];
            byteSrcAddr.CopyTo(auSrc, 0);
            nineZero.CopyTo(auSrc, Src_Addr.Length);
            byteSecret.CopyTo(auSrc, Src_Addr.Length + nineZero.Length);
            byteTimestamp.CopyTo(auSrc, Src_Addr.Length + nineZero.Length + secret.Length);

            //string s = Src_Addr + "000000000" + secret + timestamp;

            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            //Console.WriteLine(String.Format("{0}", s));

            return md5.ComputeHash(auSrc,0,auSrc.Length);

        }
        
        private string GetTimeStamp(DateTime time)
        {
            //DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            //uint timeStamp = (uint)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数            
            string s = String.Format("{0:MMddHHmmss}", time);

            //Console.WriteLine(s);

            return s;

        }

        private string getValIdTime()        //返回短信存活时间
        {
            DateTime n = DateTime.Now.AddHours(2); //2小时
            return (n.Year.ToString().Substring(2) + n.Month.ToString().PadLeft(2, '0') + n.Day.ToString().PadLeft(2, '0') + n.Hour.ToString().PadLeft(2, '0') + n.Minute.ToString().PadLeft(2, '0') + n.Second.ToString().PadLeft(2, '0') + "032+");
        }

        private string getAtTime(DateTime d)
        {
            DateTime n = d.AddSeconds(3); //2小时
            return (n.Year.ToString().Substring(2) + n.Month.ToString().PadLeft(2, '0') + n.Day.ToString().PadLeft(2, '0') + n.Hour.ToString().PadLeft(2, '0') + n.Minute.ToString().PadLeft(2, '0') + n.Second.ToString().PadLeft(2, '0') + "032+");
        }

        /// <summary>
        /// 获得包头字节
        /// </summary>
        /// <param name="Total_Lenth"></param>
        /// <param name="Command_Id"></param>
        /// <returns></returns>
        private byte[] GetHeaderBytes(int Total_Lenth,Service_Command_Id Command_Id)
        {
            byte[] header = new byte[12];
            byte[] total_lenth = new byte[4];
            byte[] command_id = new byte[4];
            byte[] sequence_id = new byte[4];

            total_lenth = BitConverter.GetBytes(Total_Lenth);
            command_id = BitConverter.GetBytes(Convert.ToUInt32(Command_Id));
            sequence_id = BitConverter.GetBytes(Convert.ToUInt32(GetTimeStamp(DateTime.Now)));

            Array.Reverse(total_lenth);
            Array.Reverse(command_id);
            Array.Reverse(sequence_id);
            //PrintBytes(total_lenth);
            //bh.GetBytesFromInt(Total_Lenth,ref total_lenth);
            //bh.GetBytesFromUint(Convert.ToUInt32(Command_Id),ref command_id);

            //需要考虑并发问题
            //bh.GetBytesFromUint(GetTimeStamp(DateTime.Now), ref sequence_id);

            List<byte[]> bytelist = new List<byte[]>();
            bytelist.Add(total_lenth);
            bytelist.Add(command_id);
            bytelist.Add(sequence_id);

            bh.BytesCombine(bytelist, ref header);

            return header;

        }

        private void PrintBytes(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {

                Console.Write(String.Format("{0:X000}" + "-", buffer[i]));

            }
        }

        #endregion

        #region 业务数据组包

        private byte[] GetRegisterMsgBytes(List<byte[]> bytes)
        {            
            byte[] res = new byte[CMPP_CONNECT_Len];
            bh.BytesCombine(bytes, ref res);

            return res;

        }

        #endregion

        public enum Service_Command_Id : uint
        {
            CMPP_CONNECT = 0x00000001,    //请求连接
            CMPP_CONNECT_RESP = 0x80000001,	//请求连接应答
            CMPP_TERMINATE = 0x00000002,	    //终止连接
            CMPP_TERMINATE_RESP = 0x80000002,     //终止连接应答
            CMPP_SUBMIT = 0x00000004,     //提交短信
            CMPP_SUBMIT_RESP = 0x80000004,    //提交短信应答
            CMPP_DELIVER = 0x00000005,     //短信下发
            CMPP_DELIVER_RESP = 0x80000005, 	 //下发短信应答
            CMPP_QUERY = 0x00000006,      //发送短信状态查询
            CMPP_QUERY_RESP = 0x80000006, 	//发送短信状态查询应答
            CMPP_CANCEL = 0x00000007,	    //删除短信
            CMPP_CANCEL_RESP = 0x80000007, 	    //删除短信应答
            CMPP_ACTIVE_TEST = 0x00000008,	    //激活测试
            CMPP_ACTIVE_TEST_RESP = 0x80000008,	    //激活测试应答
            CMPP_FWD = 0x00000009,	    //消息前转
            CMPP_FWD_RESP = 0x80000009,	    //消息前转应答
            CMPP_MT_ROUTE = 0x00000010,	    //MT路由请求
            CMPP_MT_ROUTE_RESP = 0x80000010,	    //MT路由请求应答
            CMPP_MO_ROUTE = 0x00000011,	      //MO路由请求
            CMPP_MO_ROUTE_RESP = 0x80000011,	    //MO路由请求应答
            CMPP_GET_ROUTE = 0x00000012,	    //获取路由请求
            CMPP_GET_ROUTE_RESP = 0x80000012,	    //获取路由请求应答
            CMPP_MT_ROUTE_UPDATE = 0x00000013,	    //MT路由更新
            CMPP_MT_ROUTE_UPDATE_RESP = 0x80000013,	    //MT路由更新应答
            CMPP_MO_ROUTE_UPDATE = 0x00000014,	    //MO路由更新
            CMPP_MO_ROUTE_UPDATE_RESP = 0x80000014,	    //MO路由更新应答
            CMPP_PUSH_MT_ROUTE_UPDATE = 0x00000015,	    //MT路由更新
            CMPP_PUSH_MT_ROUTE_UPDATE_RESP = 0x80000015, 	//MT路由更新应答
            CMPP_PUSH_MO_ROUTE_UPDATE = 0x00000016, 	//MO路由更新
            CMPP_PUSH_MO_ROUTE_UPDATE_RESP = 0x80000016     //MO路由更新应答

        }


    }
}
