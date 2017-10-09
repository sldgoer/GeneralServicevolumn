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
        public string SP_Id { get; private set; }
        public string Business_Id { get; private set; }
        public string User_Id { get; private set; }
        public string Secret { get; private set; }
        public string CMPP_Version { get; private set; }
        public string Ip = "";
        public int Port = 0;
        //public byte[] AuthenticatorSource { get; private set; }

        #endregion

        #region 事件定义
        public delegate void ISMG_RegistedEventHandler(object sender, ISMGEventArgs e);
        public event EventHandler<ISMGEventArgs> ISMG_Registed;

        public delegate void ISMG_MessageSubmittedEventHandler(object sender, ISMGEventArgs e);
        public event EventHandler<ISMGEventArgs> ISMG_MessageSubmitted;

        //public delegate void ISMG_Message
        #endregion

        private SClient sc = new SClient();
        private BytesHandler bh = new BytesHandler();
        
        public TextMessage(string service_id,string corp_id,string business_id,string user_id,string secret,string cmpp_version,string ip,int port)
        {
            Service_Id = service_id;
            SP_Id = corp_id;
            Business_Id = business_id;
            User_Id = user_id;
            Secret = secret;
            CMPP_Version = cmpp_version;
            Ip = ip;
            Port = port;
       
        }

        public void RegisterToISMG()
        {
            //DateTime now = DateTime.Now;
            byte[] bSource_Addr = new byte[6];
            byte[] bAuthenticatorSource = new byte[16];
            byte bVersion = new byte();
            byte[] bTimestamp = new byte[4];

            bh.GetBytesFromString(SP_Id,ref bSource_Addr,'\0',BytesHandler.CoverSide.Left);
            bTimestamp = BitConverter.GetBytes(GetTimeStamp(DateTime.Now));
            bVersion = GetVersionByte(CMPP_Version);
            bAuthenticatorSource = GetAuthenticatorSource(bSource_Addr, Encoding.ASCII.GetBytes(Secret), bTimestamp);

            Console.WriteLine(Encoding.ASCII.GetString(bSource_Addr));
            Console.WriteLine(Encoding.ASCII.GetString(bTimestamp));
            Console.WriteLine(Encoding.ASCII.GetString(bAuthenticatorSource));


        }

        public void SendMessage(List<string> mobilenumbers,string content)
        {
            int mobileCount = mobilenumbers.Count;


        }

        private void InitialSocket()
        {
            //SocketClient sc = new SocketClient();
            sc.Socket_OK += new EventHandler<SocketClientEventArgs>(SocketOKEventHandler);
            sc.ismgIP = Ip;
            sc.port = Port;
            sc.StartClient();
        }

        private void SocketOKEventHandler(object sender,SocketClientEventArgs e)
        {
            Console.WriteLine("Socket is OK!");
        }

        private byte GetVersionByte(string versionString)
        {
            var s = versionString.Split('.');
            uint highBit = uint.Parse(s[0])<<4;
            uint lowBit = uint.Parse(s[1]);
                        
            var result = (byte)(highBit | lowBit);

            return result;
        }
                
        private byte[] GetAuthenticatorSource(byte[] Src_Addr,byte[] secret,byte[] timestamp)
        {
            byte[] nineZero = new byte[9];
            for(int i = 0; i < nineZero.Length; i++)
            {
                nineZero[i] = 0x0000;
            }

            byte[] auSrc = new byte[Src_Addr.Length + nineZero.Length + secret.Length + timestamp.Length];
            Src_Addr.CopyTo(auSrc, 0);
            nineZero.CopyTo(auSrc, Src_Addr.Length);
            secret.CopyTo(auSrc, nineZero.Length);
            timestamp.CopyTo(auSrc, secret.Length);

            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return md5.ComputeHash(auSrc);

        }
        
        private UInt32 GetTimeStamp(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            uint timeStamp = (uint)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数            
            return timeStamp;

        }

    }
}
