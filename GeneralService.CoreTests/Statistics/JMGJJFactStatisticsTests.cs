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
    public class JMGJJFactStatisticsTests
    {
        [TestMethod()]
        public void BusinessVolumnStatisticsTest()
        {
            JMGJJFactStatistics jfs = new JMGJJFactStatistics();
            DateTime dtBegin = Convert.ToDateTime("2017-1-1");
            DateTime dtEnd = Convert.ToDateTime("2017-1-31");


            Console.Write(jfs.BusinessVolumnStatistics(dtBegin, dtEnd));
            //Assert.Fail();
        }
    }
}