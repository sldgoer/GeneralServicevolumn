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
    public class WebQueryStatisticsTests
    {
        [TestMethod()]
        public void getWebQueryStatisticsTest()
        {
            WebQueryStatistics wqs = new WebQueryStatistics();
            var date = Convert.ToDateTime("2017-9-1");
            var res = wqs.getWebQueryStatistics(@"H:\Log", date);

            Console.Write(res);
            Assert.Fail();
        }
    }
}