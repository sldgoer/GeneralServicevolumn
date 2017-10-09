using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralService.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Statistics.Tests
{
    [TestClass()]
    public class WeixinQueryStatisticsTests
    {
        [TestMethod()]
        public void getWeixinQueryStatisticsTest()
        {
            WeixinQueryStatistics wqs = new WeixinQueryStatistics();
            var date = Convert.ToDateTime("2017-9-1");
            var res = wqs.getWeixinQueryStatistics(@"H:\Log", date);
            //Assert.IsTrue(res>1388);
            //Assert.IsInstanceOfType(date, typeof(DateTime));
            //Assert.IsNotNull(res);
            //Assert.IsInstanceOfType(res, typeof(int));
            Console.Write(res);

            Assert.Fail();
        }
    }
}