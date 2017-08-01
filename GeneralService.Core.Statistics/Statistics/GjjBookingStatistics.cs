using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Statistics
{
    using Models;
    using System.Data.Objects;
    using Newtonsoft.Json;

    public class GjjBookingStatistics
    {
        
        //GjjBookingEntities gjjbookingEntities = new GjjBookingEntities();
        public string BookingPlatFormVolumnStatistics(DateTime DateBegin,DateTime DateEnd)
        {
            //if ((DateEnd.Subtract(DateBegin)).TotalSeconds < 0) { return}
            using(GjjBookingEntities gjjbookEntities =new GjjBookingEntities())
            {
                var res = gjjbookEntities.BookingRecord.Where(x => DateTime.Compare(x.date, DateBegin) >= 0 && EntityFunctions.DiffDays(x.date, DateEnd) <= 0).GroupBy(g => new { g.name, g.callPlatform }).Select(x => new { Name = x.Key.name, CallPlatForm = x.Key.callPlatform, Count = x.Count() });
                return JsonConvert.SerializeObject(res);
            }
            //return 0;
        }

    }
}
