using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenaralService.Utility.FileUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenaralService.Utility.TextFileUtility.Tests
{
    [TestClass()]
    public class txtContentHandlerTests
    {
        [TestMethod()]
        public void getTxtAllLinesStringTest()
        {
            txtContentHandler tch = new txtContentHandler();
            var res = tch.getTxtAllLinesString(@"F:\2017-01-11.log");
            Assert.IsTrue(res[1].Length>0);
            Assert.IsTrue(res[1].IndexOf("header") >=0);
        }
    }
}