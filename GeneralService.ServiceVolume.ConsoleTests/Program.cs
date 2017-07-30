using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.ServiceVolume.ConsoleTests
{
    using GeneralService.Core.Statistics;
    class Program
    {
        
        static void Main(string[] args)
        {
            WeixinQueryStatistics weixinQS = new WeixinQueryStatistics();
            WebQueryStatistics webQS = new WebQueryStatistics();

            var date = Convert.ToDateTime("2017-01-01");
            var logDir = @"F:\Log";

            var weixinQSVol = weixinQS.getWeixinQueryStatistics(logDir, date);
            var webQSVol = webQS.getWebQueryStatistics(logDir, date);

            Console.WriteLine(weixinQSVol);
            Console.WriteLine(webQSVol);
            Console.ReadKey();
        }
    }
}
