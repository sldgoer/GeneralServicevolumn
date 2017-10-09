using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.ServiceVolume.ConsoleTests
{
    using Core.Statistics;
    using Newtonsoft.Json;

    class Program
    {
        
        static void Main(string[] args)
        {
            JMGJJFactStatistics jfs = new JMGJJFactStatistics();
            JmgjjPreliminaryStatistics jps = new JmgjjPreliminaryStatistics();
            DateTime dtBegin = Convert.ToDateTime("2017-9-1");
            DateTime dtEnd = Convert.ToDateTime("2017-9-30");

            while (dtBegin.Month == 9)
            {
                Console.WriteLine("========================" + dtBegin.Month + "月======================");

                try
                {
                    var JsonTotalStatistics = jfs.BusinessVolumnStatistics(dtBegin, dtEnd);
                    var JsonPrePersonStatistics = jps.PrePersonBusinessStatistics(dtBegin, dtEnd);
                    var JsonPreUnitStatistics = jps.PreUnitBusinessStatistics(dtBegin, dtEnd);

                    List<BusinessStatistics> bsVolList,unitVolList = new List<BusinessStatistics>();
                    List<PersonBusinessStatistics> personVolList = new List<PersonBusinessStatistics>();

                    bsVolList = JsonConvert.DeserializeObject<List<BusinessStatistics>>(JsonTotalStatistics);
                    personVolList = JsonConvert.DeserializeObject<List<PersonBusinessStatistics>>(JsonPrePersonStatistics);
                    unitVolList = JsonConvert.DeserializeObject<List<BusinessStatistics>>(JsonPreUnitStatistics);

                    dtBegin = dtBegin.AddMonths(1);
                    dtEnd = dtEnd.AddMonths(1);

                    foreach (var b in bsVolList)
                    {
                        Console.WriteLine(b);
                    }
                    foreach(var p in personVolList)
                    {
                        Console.WriteLine(p);
                    }
                    foreach(var u in unitVolList)
                    {
                        Console.WriteLine(u);
                    }



                }
                catch(Exception ex)
                {
                    Console.WriteLine("出错：" + ex.Message.ToString());
                }

                Console.WriteLine("=================================================================");

            }

            Console.Write(jps.PrePersonBusinessStatistics(dtBegin, dtEnd));

            //Console.Write(gbs.BookingPlatFormVolumnStatistics(dtBegin, dtEnd));
            Console.ReadKey();
        }
    }

    class BusinessStatistics
    {
        public string BusinessName { get; set; }
        public long Count { get; set; }

        public override string ToString()
        {
            return string.Format("BusinessName:{0}; Count:{1}", BusinessName, Count);
        }
    }
    class PersonBusinessStatistics
    {
        public string BusinessName { get; set; }
        public string CallPlatForm { get; set; }
        public long Count { get; set; }

        public override string ToString()
        {
            return string.Format("BusinessName:{0}; CallPlatForm:{1}; Count:{2}", BusinessName, CallPlatForm, Count);
        }
    }
}
