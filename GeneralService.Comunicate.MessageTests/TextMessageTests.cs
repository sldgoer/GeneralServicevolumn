using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralService.Comunicate.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Comunicate.Message.Tests
{
    [TestClass()]
    public class TextMessageTests
    {
        [TestMethod()]
        public void StartClientTest()
        {
            SocketClient tm = new SocketClient();
            tm.ismgIP = "211.139.144.201";
            tm.port = 7890;
            tm.StartClient();

            Assert.Fail();
        }
    }
}