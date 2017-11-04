using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralService.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Message.Tests
{
    [TestClass()]
    public class TextMessageTests
    {
        [TestMethod()]
        public void RegisterToISMGTest()
        {
            //服务代码106573401021

            //企业代码999999

            //业务代码MGD0019900

            //登录网关帐号名称J01615

            //登录网关密码RMZVv%9U(似乎没用)

            //网关IP地址211.139.144.201

            //网关服务端口号7890

            
            
            TextMessage tm = new TextMessage("106573401021", "999999", "MGD0019900", "J01615", "RMZVv%9U", "2.0", "211.139.144.201", 7890);
            tm.Socket_Connected += new EventHandler<Models.ISMGEventArgs>(SocketConnectedEventHandler);

            //tm.RegisterToISMG();


            while (true) {  }

            Assert.Fail();
            
        }

        private void SocketConnectedEventHandler(object sender,Models.ISMGEventArgs e)
        {
            TextMessage tm = (TextMessage)sender;
            Console.WriteLine("SocketConnected event up!!!"+e.Message);
            lock (this)
            {
                tm.RegisterToISMG();
            }
            
            
        }



    }
}