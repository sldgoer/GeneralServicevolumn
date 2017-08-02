using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Statistics
{
    using Models;
    using Newtonsoft.Json;

    public class JmgjjPreliminaryStatistics
    {
        JmgjjPreliminaryEntities jmgjjpreliminaryentities = new JmgjjPreliminaryEntities();

        public string PrePersonBusinessStatistics(DateTime DateBegin,DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);//由于DateEnd时间为零点，肯定比审批时间小，因此要用AddDays函数
            var res = jmgjjpreliminaryentities.A033PreFetch                
                .Where(x => DateTime.Compare(x.ondate.Value, DateBegin) >= 0 && DateTime.Compare(x.ondate.Value, DateEnd) <0 && x.isdel==false)
                .GroupBy(g => g.editor)
                .Select(s => new { CallPlatForm = s.Key, Count=s.Count() });

            return JsonConvert.SerializeObject(res);
        }
    }
}
