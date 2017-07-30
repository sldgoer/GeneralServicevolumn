using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenaralService.Utility.FileUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenaralService.Utility.FileUtility.Tests
{
    //using Utility;
    [TestClass()]
    public class FilesHandlerTests
    {
        FilesHandler fh = new FilesHandler();

        [TestMethod()]
        public void getFilenamesFromFolderTest()
        {
            //string filename = @"F:\2017-01-11.log";
            var res = fh.getFilenamesFromFolder(@"F:\Log", "*.log");
            Assert.IsTrue(res.Count > 1);
        }

        [TestMethod()]
        public void getFileDateFromNameTest()
        {
            var res = fh.getFileDateFromName("2017-01-11.log", 0, 10);
            var date = Convert.ToDateTime("2017-01-11");
            Assert.AreEqual(date, res);
        }
    }
}