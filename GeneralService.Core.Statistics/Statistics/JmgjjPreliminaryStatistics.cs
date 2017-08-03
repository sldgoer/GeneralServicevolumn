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

        public string PreUnitBusinessStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            List<object> _UnitBSVolList = new List<object>();

            _UnitBSVolList.Add(new { BusinessName = "个人开户预审", Count = PreAccountVolumnStatistics(DateBegin, DateEnd) });
            _UnitBSVolList.Add(new { BusinessName = "封存预审", Count = PreLockVolumnStatistics(DateBegin, DateEnd) });
            _UnitBSVolList.Add(new { BusinessName = "启封预审", Count = PreUnlockVolumnStatistics(DateBegin, DateEnd) });
            _UnitBSVolList.Add(new { BusinessName = "补缴预审", Count = PreBujiaoVolumnStatistics(DateBegin, DateEnd) });
            _UnitBSVolList.Add(new { BusinessName = "基数调整预审", Count = PreJctzVolumnStatistics(DateBegin, DateEnd) });
            _UnitBSVolList.Add(new { BusinessName = "职工转入预审", Count = PreTranInVolumnStatistics(DateBegin, DateEnd) });

            return JsonConvert.SerializeObject(_UnitBSVolList);
        }

        #region 私有方法
        /// <summary>
        /// 单位开通预审业务统计
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        private long PreUnitSubmitStatistics(DateTime DateBegin,DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);

            return jmgjjpreliminaryentities.A030PreUnit
                .Where(x => DateTime.Compare(x.ondate.Value, DateBegin) >= 0 && DateTime.Compare(x.ondate.Value, DateEnd) < 0 && x.isdel == false)
                .Count();

        }

        /// <summary>
        /// 个人开户预审统计
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        private long PreAccountVolumnStatistics(DateTime DateBegin,DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);

            return jmgjjpreliminaryentities.A034preAccount_1
                .Where(x => DateTime.Compare(x.ondate.Value, DateBegin) >= 0 && DateTime.Compare(x.ondate.Value, DateEnd) < 0 && x.isdel == false)
                .Count();
        }

        /// <summary>
        /// 封存预审统计
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        private long PreLockVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);

            return jmgjjpreliminaryentities.A035preLock_1
                .Where(x => DateTime.Compare(x.ondate.Value, DateBegin) >= 0 && DateTime.Compare(x.ondate.Value, DateEnd) < 0 && x.isdel == false )
                .Count();

        }

        /// <summary>
        /// 启封预审统计
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        private long PreUnlockVolumnStatistics(DateTime DateBegin,DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);

            return jmgjjpreliminaryentities.A035preUnLock_1
                .Where(x => DateTime.Compare(x.ondate.Value, DateBegin) >= 0 && DateTime.Compare(x.ondate.Value, DateEnd) < 0 && x.isdel == false )
                .Count();
        }

        /// <summary>
        /// 补缴预审统计
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        private long PreBujiaoVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);

            return jmgjjpreliminaryentities.A036preBujiao_1
                .Where(x => DateTime.Compare(x.ondate.Value, DateBegin) >= 0 && DateTime.Compare(x.ondate.Value, DateEnd) < 0 && x.isdel == false )
                .Count();

        }

        /// <summary>
        /// 基数调整预审统计
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        private long PreJctzVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);

            return jmgjjpreliminaryentities.A037preJctz_1
                .Where(x => DateTime.Compare(x.ondate.Value, DateBegin) >= 0 && DateTime.Compare(x.ondate.Value, DateEnd) < 0 && x.isdel == false)
                .Count();

        }


        /// <summary>
        /// 转入预审统计
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        private long PreTranInVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            DateEnd = DateEnd.AddDays(1);

            return jmgjjpreliminaryentities.A038TranIn_1
                .Where(x => DateTime.Compare(x.ondate.Value, DateBegin) >= 0 && DateTime.Compare(x.ondate.Value, DateEnd) < 0 && x.isdel == false)
                .Count();

        }

        #endregion
    }

}
