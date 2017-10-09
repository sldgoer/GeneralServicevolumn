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
    public class GjjBookingStatisticsTests
    {
        [TestMethod()]
        public void BookingPlatFormVolumnStatisticsTest()
        {
            GjjBookingStatistics gbs = new GjjBookingStatistics();
            DateTime dtBegin = Convert.ToDateTime("2017-9-1");
            DateTime dtEnd = Convert.ToDateTime("2017-9-30");
            var res = gbs.BookingCompleteVolumnStatistics(dtBegin, dtEnd);
            Console.WriteLine(res);
            Assert.Fail();
        }
    }
}