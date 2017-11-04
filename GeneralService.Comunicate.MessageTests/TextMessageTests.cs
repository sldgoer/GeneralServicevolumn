using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralService.Comunicate.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralService.Message.Tests
{

    using Message;

    [TestClass()]
    public class TextMessageTests
    {
        [TestMethod()]
        public void StartClientTest()
        {
            tex
            tm.ismgIP = "211.139.144.201";
            tm.port = 7890;
            tm.Socket_OK += new EventHandler<SocketClient.Models.SocketClientEventArgs>(SocketOKEventHadler);

            tm.StartClient();

            Assert.Fail();
        }

        private void SocketOKEventHadler(object sender,SocketClient.Models.SocketClientEventArgs e)
        {
            
            Console.Write(e.Feeckback.ToString());
        }
    }
}