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
        public void GetBytesFromUintTest()
        {
            uint u = 10;
            byte[] des = new byte[4];
            BytesHandler bh = new BytesHandler();
            bh.GetBytesFromUint(u, ref des);
            Console.WriteLine(BitConverter.ToInt16(des, 0).ToString());

            Assert.Fail();
        }

        [TestMethod()]
        public void GetBytesFromStringTest()
        {
            string s = "9";
            byte[] des = new byte[6];
            BytesHandler bh = new BytesHandler();
            bh.GetBytesFromString(s, ref des, '\0', BytesHandler.CoverSide.Left);
            Console.WriteLine(Encoding.ASCII.GetString(des));

            Assert.Fail();
        }
    }
}