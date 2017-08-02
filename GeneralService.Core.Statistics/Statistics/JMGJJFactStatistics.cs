using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Statistics
{
    using Models;
    using Newtonsoft.Json;
    
    public class JMGJJFactStatistics
    {
        JMGJJFactEntities jmgjjfactEntities = new JMGJJFactEntities();

        public string BusinessVolumnStatistics(DateTime DateBegin,DateTime DateEnd)
        {
            List<object> _BSVolList = new List<object>();
            DateEnd = DateEnd.AddDays(1);//由于DateEnd时间为零点，肯定比审批时间小，因此要用AddDays函数

            _BSVolList.Add(new { BusinessName = "个人开户", Count = t_accountVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "自动提取", Count = t_account_autofetchVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "单位开户", Count = t_account_companyVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "普通提取", Count = t_account_fetchVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "贷款审批", Count = t_account_loanVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "封存审批", Count = t_account_lockVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "启封审批", Count = t_account_unlockVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "补缴审批", Count = t_account_patchVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "转移审批", Count = t_account_transferVolumnStatistics(DateBegin, DateEnd) });
            _BSVolList.Add(new { BusinessName = "基数调整", Count = t_salary_infoVolumnStatistics(DateBegin, DateEnd) });

            return JsonConvert.SerializeObject(_BSVolList);

        }

        /// <summary>
        /// 个人开户数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_accountVolumnStatistics(DateTime DateBegin,DateTime DateEnd)
        {            
            return jmgjjfactEntities.t_account
                .Where(x => DateTime.Compare(x.sign_time.Value, DateBegin) >= 0 && DateTime.Compare(x.sign_time.Value, DateEnd) < 0 && x.Status != -2)
                .Select(x=>x.Id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 自动提取审批数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_account_autofetchVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {            
            return jmgjjfactEntities.t_account_autofetch
                .Where(x => DateTime.Compare(x.sign_time.Value, DateBegin) >= 0 && DateTime.Compare(x.sign_time.Value, DateEnd) < 0 && x.sign_tag >1)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 单位开户数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_account_companyVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            return jmgjjfactEntities.t_account_company
                .Where(x => DateTime.Compare(x.sign_time.Value, DateBegin) >= 0 && DateTime.Compare(x.sign_time.Value, DateEnd) < 0 && x.status != -1)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 普通提取数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_account_fetchVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            return jmgjjfactEntities.t_account_fetch
                .Where(x => DateTime.Compare(x.sign_time.Value, DateBegin) >= 0 && DateTime.Compare(x.sign_time.Value, DateEnd) < 0 && x.sign_tag > 1 && x.is_delete != 1)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 贷款审批数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_account_loanVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            return jmgjjfactEntities.t_account_loan
                .Where(x => DateTime.Compare(x.final_confirm_time.Value, DateBegin) >= 0 && DateTime.Compare(x.final_confirm_time.Value, DateEnd) < 0 && x.sign_tag > 2)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 封存数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_account_lockVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            return jmgjjfactEntities.t_account_lock_and_unlock
                .Where(x => DateTime.Compare(x.sign_time.Value, DateBegin) >= 0 && DateTime.Compare(x.sign_time.Value, DateEnd) < 0 && x.tag == 1 && x.is_delete != 1 && x.sign_tag > 0)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 启封数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_account_unlockVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            return jmgjjfactEntities.t_account_lock_and_unlock
                .Where(x => DateTime.Compare(x.sign_time.Value, DateBegin) >= 0 && DateTime.Compare(x.sign_time.Value, DateEnd) < 0 && x.tag != 1 && x.is_delete != 1 && x.sign_tag > 0)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 补缴数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_account_patchVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            return jmgjjfactEntities.t_account_patch
                .Where(x => DateTime.Compare(x.sign_time.Value, DateBegin) >= 0 && DateTime.Compare(x.sign_time.Value, DateEnd) < 0 && x.is_delete != 1 && x.sign_tag > 0)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 转移数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_account_transferVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            return jmgjjfactEntities.t_account_transfer
                .Where(x => DateTime.Compare(x.sign_time.Value, DateBegin) >= 0 && DateTime.Compare(x.sign_time.Value, DateEnd) < 0 && x.is_delete != 1 && x.sign_tag > 0)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

        /// <summary>
        /// 基数调整数统计
        /// </summary>
        /// <param name="DateBegin">开始日期</param>
        /// <param name="DateEnd">结束日期</param>
        /// <returns></returns>
        private long t_salary_infoVolumnStatistics(DateTime DateBegin, DateTime DateEnd)
        {
            return jmgjjfactEntities.t_salary_info
                .Where(x => DateTime.Compare(x.import_time.Value, DateBegin) >= 0 && DateTime.Compare(x.import_time.Value, DateEnd) <= 0 && x.is_delete != 1 && x.is_TransferAdjust_tag.Value != true && x.is_delete != 1)
                .Select(x => x.id)
                .Distinct()
                .Count();

        }

    }
}
