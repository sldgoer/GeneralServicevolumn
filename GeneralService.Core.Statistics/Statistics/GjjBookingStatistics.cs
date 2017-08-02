using System;
using System.Linq;

namespace GeneralService.Core.Statistics
{
    using Models;
    using Newtonsoft.Json;

    public class GjjBookingStatistics
    {
        
        /// <summary>
        /// 分业务分平台统计预约总数
        /// </summary>
        /// <param name="DateBegin">查询开始日期</param>
        /// <param name="DateEnd">查询结束日期</param>
        /// <returns></returns>
        public string BookingPlatFormVolumnStatistics(DateTime DateBegin,DateTime DateEnd)
        {
            //if ((DateEnd.Subtract(DateBegin)).TotalSeconds < 0) { return}
            DateEnd = DateEnd.AddDays(1);//由于DateEnd时间为零点，肯定比审批时间小，因此要用AddDays函数
            using (GjjBookingEntities gjjbookEntities =new GjjBookingEntities())
            {
                var res = gjjbookEntities.BookingRecord
                    .Where(x => DateTime.Compare(x.date, DateBegin) >= 0 && DateTime.Compare(x.date, DateEnd) <= 0)
                    .GroupBy(g => new { g.name, g.callPlatform })
                    .Select(x => new { Name = x.Key.name, CallPlatForm = x.Key.callPlatform, Count = x.Count() });
                return JsonConvert.SerializeObject(res);
            }
            //return 0;
        }

        /// <summary>
        /// 分业务分平台统计办结预约总数
        /// </summary>
        /// <param name="DateBegin">查询开始日期</param>
        /// <param name="DateEnd">查询结束日期</param>
        /// <returns></returns>
        public string BookingCompleteVolumnStatistics(DateTime DateBegin,DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);//由于DateEnd时间为零点，肯定比审批时间小，因此要用AddDays函数
            using (GjjBookingEntities gjjbookEntities = new GjjBookingEntities())
            {
                var res = gjjbookEntities.BookingRecord
                    .Where(x => DateTime.Compare(x.date, DateBegin) >= 0 && DateTime.Compare(x.date, DateEnd) <= 0 && x.state == 1)
                    .GroupBy(g => new { g.name, g.callPlatform })
                    .Select(x => new { Name = x.Key.name, CallPlatForm = x.Key.callPlatform, Count = x.Count() });
                return JsonConvert.SerializeObject(res);
            }
        }

    }
}
