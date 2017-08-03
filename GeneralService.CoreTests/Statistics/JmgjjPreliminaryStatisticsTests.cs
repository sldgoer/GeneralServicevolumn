using GeneralService.Core.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralService.Core.Statistics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Statistics.Tests
{
    [TestClass()]
    public class JmgjjPreliminaryStatisticsTests
    {
        JmgjjPreliminaryStatistics jps = new JmgjjPreliminaryStatistics();

        [TestMethod()]
        public void PreUnitSubmitStatisticsTest()
        {
            DateTime dtBegin = Convert.ToDateTime("2017-1-1");
            DateTime dtEnd = Convert.ToDateTime("2017-1-31");

            Console.Write(jps.PrePersonBusinessStatistics(dtBegin, dtEnd));

            //Assert.Fail();
        }

        [TestMethod()]
        public void PreAccountVolumnStatisticsTest()
        {
            DateTime dtBegin = Convert.ToDateTime("2017-1-1");
            DateTime dtEnd = Convert.ToDateTime("2017-1-31");

            //Console.Write(jps.PreAccountVolumnStatistics(dtBegin, dtEnd));
            //Assert.Fail();
        }

        [TestMethod()]
        public void PreLockVolumnStatisticsTest()
        {
            DateTime dtBegin = Convert.ToDateTime("2017-1-1");
            DateTime dtEnd = Convert.ToDateTime("2017-1-31");

            //Console.Write(jps.PreLockVolumnStatistics(dtBegin, dtEnd));

            //Assert.Fail();
        }

        [TestMethod()]
        public void PreUnlockVolumnStatisticsTest()
        {
            DateTime dtBegin = Convert.ToDateTime("2017-2-1");
            DateTime dtEnd = Convert.ToDateTime("2017-2-28");

            //Console.Write(jps.PreUnlockVolumnStatistics(dtBegin, dtEnd));
            //Assert.Fail();
        }

        [TestMethod()]
        public void PreBujiaoVolumnStatisticsTest()
        {
            DateTime dtBegin = Convert.ToDateTime("2017-2-1");
            DateTime dtEnd = Convert.ToDateTime("2017-2-28");

            //Console.Write(jps.PreUnlockVolumnStatistics(dtBegin, dtEnd));
            //Assert.Fail();
        }

        [TestMethod()]
        public void PreJctzVolumnStatisticsTest()
        {
            DateTime dtBegin = Convert.ToDateTime("2017-2-1");
            DateTime dtEnd = Convert.ToDateTime("2017-2-28");

            //Console.Write(jps.PreJctzVolumnStatistics(dtBegin, dtEnd));
            //Assert.Fail();
        }

        [TestMethod()]
        public void PreTranInVolumnStatisticsTest()
        {
            DateTime dtBegin = Convert.ToDateTime("2017-2-1");
            DateTime dtEnd = Convert.ToDateTime("2017-2-28");

            //Console.Write(jps.PreTranInVolumnStatistics(dtBegin, dtEnd));
            //Assert.Fail();
        }

        [TestMethod()]
        public void PreUnitBusinessStatisticsTest()
        {
            DateTime dtBegin = Convert.ToDateTime("2017-7-1");
            DateTime dtEnd = Convert.ToDateTime("2017-7-31");

            Console.Write(jps.PreUnitBusinessStatistics(dtBegin, dtEnd));
        }
    }
}

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