using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralService.Core.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GeneralService.Core.Message.Tests
{
    [TestClass()]
    public class TextMessageTests
    {
        [TestMethod()]
        public void ConnectToISMGTest()
        {
            TextMessage tm = new TextMessage();
            tm.ConnectToISMG(new Models.CMPP_CONNECT());

            Assert.Fail();
        }

        [TestMethod()]
        public void EstablishSocketTest()
        {
            const string ismg_Ip = "211.139.144.201";
            const int port = 7890;
            const string SP_Id = "999999";
            const string Service_Id = "MGD0019900";
            const string Src_Id = "106573401021";
            const string SP_Account = "J01615";
            const string SP_Secrect = "RMZVv%9U";

            TextMessage tm = new TextMessage();
            tm.EstablishSocket(ismg_Ip,port);
            
            Models.CMPP_CONNECT cc = new Models.CMPP_CONNECT();
            cc.Total_Length = cc.Header_Len + cc.Body_Len;
            cc.Command_Id = 0x00000001;
            cc.Sequence_Id = 0x00000001;
            cc.Source_Addr = SP_Id;

            MD5 md5 = new MD5CryptoServiceProvider();

            cc.AuthenticatorSource=md5.ComputeHash()

            Assert.Fail();
        }
    }
}