using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Message
{
    using Comunicate.SocketClient;
    using Comunicate.SocketClient.Models;
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
        public string Service_Id { get; set; }
        public string SP_Id { get; set; }
        public string Business_Id { get; set; }
        public string User_Id { get; set; }
        public string Secret { get; set; }
        public string Ip = "";
        public int Port = 0;
        #endregion

        #region 事件定义
        public delegate void ISMG_RegistedEventHander(object sender, EventArgs e);
        #endregion

        private SocketClient sc = new SocketClient();


        public TextMessage(string service_id,string corp_id,string business_id,string user_id,string secret,string ip,int port)
        {
            Service_Id = service_id;
            SP_Id = corp_id;
            Business_Id = business_id;
            User_Id = user_id;
            Secret = secret;
            Ip = ip;
            Port = port;
       
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
                

    }
}
