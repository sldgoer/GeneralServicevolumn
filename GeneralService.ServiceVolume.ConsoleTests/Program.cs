using System;
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
            GjjBookingStatistics gbs = new GjjBookingStatistics();
            DateTime dtBegin = Convert.ToDateTime("2017-7-1");
            DateTime dtEnd = Convert.ToDateTime("2017-7-31");

            Console.Write(gbs.BookingPlatFormVolumnStatistics(dtBegin, dtEnd));
        }
    }
}
