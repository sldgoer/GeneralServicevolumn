//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeneralService.Core.Statistics.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_account_autofetch
    {
        public int id { get; set; }
        public Nullable<int> datalevel { get; set; }
        public Nullable<int> loan_id { get; set; }
        public string input_user { get; set; }
        public Nullable<System.DateTime> input_time { get; set; }
        public string modify_user { get; set; }
        public Nullable<System.DateTime> modify_time { get; set; }
        public Nullable<int> sign_tag { get; set; }
        public string sign_user { get; set; }
        public Nullable<System.DateTime> sign_time { get; set; }
        public string sign_modify_user { get; set; }
        public Nullable<System.DateTime> sign_modify_time { get; set; }
        public string number_id { get; set; }
        public Nullable<decimal> accrual_i { get; set; }
        public Nullable<decimal> accrual_b { get; set; }
        public Nullable<int> print_tag { get; set; }
        public Nullable<System.DateTime> sign_date { get; set; }
        public Nullable<System.DateTime> begin_date { get; set; }
        public Nullable<System.DateTime> cancel_time { get; set; }
        public string cancel_user { get; set; }
        public Nullable<decimal> up_limit_money { get; set; }
        public Nullable<int> a_id { get; set; }
        public string relate_id { get; set; }
        public string remark { get; set; }
        public string LoanAccount { get; set; }
        public string BizLoanAccount { get; set; }
        public Nullable<System.DateTime> stop_date { get; set; }
        public string zhifumima { get; set; }
        public string receptor { get; set; }
        public string recept_account { get; set; }
        public Nullable<int> recept_bank { get; set; }
        public Nullable<int> notice_id { get; set; }
        public string notice_str { get; set; }
        public Nullable<System.DateTime> print_date { get; set; }
        public Nullable<decimal> biz_loan_balance { get; set; }
        public Nullable<decimal> loan_balance { get; set; }
        public Nullable<int> up_limit_term { get; set; }
        public Nullable<System.DateTime> lapse_date { get; set; }
        public Nullable<decimal> AVG_GiveBack_Money { get; set; }
        public Nullable<decimal> Biz_AVG_GiveBack_Money { get; set; }
        public string giveback_account { get; set; }
        public string account_name { get; set; }
        public Nullable<bool> Is_BankTransfer { get; set; }
        public string Bank_Card { get; set; }
        public Nullable<System.DateTime> LoanBDate { get; set; }
        public Nullable<System.DateTime> LoanEDate { get; set; }
        public Nullable<System.DateTime> BizLoanBDate { get; set; }
        public Nullable<System.DateTime> BizLoanEDate { get; set; }
        public Nullable<int> LoanTerm { get; set; }
        public Nullable<int> BizLoanTerm { get; set; }
        public string name { get; set; }
        public string u_name { get; set; }
        public string id_card { get; set; }
        public Nullable<int> old_loan_id { get; set; }
        public Nullable<int> Cancel_Id { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.DateTime> Backup_sign_time { get; set; }
        public Nullable<bool> Fact_Cancel { get; set; }
        public Nullable<int> Old_Sign_tag { get; set; }
    }
}
