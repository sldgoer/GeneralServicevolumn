using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralService.Core.Statistics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Statistics.Statistics.Tests
{
    [TestClass()]
    public class JmgjjPreliminaryStatisticsTests
    {
        [TestMethod()]
        public void PrePersonBusinessStatisticsTest()
        {
            JmgjjPreliminaryStatistics jps = new JmgjjPreliminaryStatistics();
            DateTime dtBegin = Convert.ToDateTime("2017-1-1");
            DateTime dtEnd = Convert.ToDateTime("2017-1-31");


            Console.Write(jps.PrePersonBusinessStatistics(dtBegin, dtEnd));
            //Assert.Fail();
        }
    }
}