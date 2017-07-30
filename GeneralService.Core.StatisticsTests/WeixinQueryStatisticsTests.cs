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
            var date = Convert.ToDateTime("2017-01-11");
            var res = wqs.getWeixinQueryStatistics(@"F:\Log", date);
            Assert.IsTrue(res>1388);
            //Assert.IsInstanceOfType(date, typeof(DateTime));
            //Assert.IsNotNull(res);
            Assert.IsInstanceOfType(res, typeof(int));
            //Assert.Fail();
        }
    }
}