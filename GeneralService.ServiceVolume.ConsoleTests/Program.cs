﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.ServiceVolume.ConsoleTests
{
    using Core.Statistics;
    

    class Program
    {
        
        static void Main(string[] args)
        {
            JmgjjPreliminaryStatistics jps = new JmgjjPreliminaryStatistics();
            DateTime dtBegin = Convert.ToDateTime("2017-1-1");
            DateTime dtEnd = Convert.ToDateTime("2017-1-31");


            Console.Write(jps.PrePersonBusinessStatistics(dtBegin, dtEnd));

            //Console.Write(gbs.BookingPlatFormVolumnStatistics(dtBegin, dtEnd));
            Console.ReadKey();
        }
    }
}
