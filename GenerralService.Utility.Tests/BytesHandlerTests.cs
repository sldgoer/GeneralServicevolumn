using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralService.Utility.ByteUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Utility.ByteUtility.Tests
{
    [TestClass()]
    public class BytesHandlerTests
    {
        [TestMethod()]
        public void GetBytesFromStringTest()
        {
            string s = "999999";
            byte[] res = new byte[6];
            BytesHandler bh = new BytesHandler();
            bh.GetBytesFromString(s, ref res, '\0', BytesHandler.CoverSide.Left);

            Console.WriteLine(Encoding.ASCII.GetString(res));

            Assert.Fail();
        }
    }
}