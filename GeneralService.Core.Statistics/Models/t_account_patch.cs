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
    
    public partial class t_account_patch
    {
        public int id { get; set; }
        public string fgb_account { get; set; }
        public string u_name { get; set; }
        public int bank { get; set; }
        public string bank_card { get; set; }
        public int a_id { get; set; }
        public Nullable<int> u_id { get; set; }
        public string id_card { get; set; }
        public string account { get; set; }
        public decimal repair_money { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public System.DateTime begin_date { get; set; }
        public System.DateTime end_date { get; set; }
        public Nullable<int> tag { get; set; }
        public string remark { get; set; }
        public Nullable<int> xml_id { get; set; }
        public Nullable<int> out_tag { get; set; }
        public string tickit_remark { get; set; }
        public Nullable<int> sign_tag { get; set; }
        public string input_user { get; set; }
        public Nullable<System.DateTime> input_time { get; set; }
        public string sign_user { get; set; }
        public Nullable<System.DateTime> sign_time { get; set; }
        public Nullable<bool> over_area_tag { get; set; }
        public string over_area_unit_name { get; set; }
        public string bill_no { get; set; }
        public Nullable<int> area_code { get; set; }
        public Nullable<decimal> after_money { get; set; }
        public Nullable<System.DateTime> sign_date { get; set; }
        public Nullable<decimal> u_bili { get; set; }
        public Nullable<decimal> i_bili { get; set; }
        public Nullable<bool> is_margin_patch_tag { get; set; }
        public Nullable<int> is_delete { get; set; }
        public string number_id { get; set; }
        public Nullable<decimal> salary_amount { get; set; }
        public Nullable<int> noNumberID { get; set; }
        public Nullable<decimal> u_repair_money { get; set; }
        public Nullable<decimal> i_repair_money { get; set; }
        public string K3HandBillRefPiHao { get; set; }
        public Nullable<bool> transfer_in_tag { get; set; }
        public Nullable<bool> is_ration_patch_tag { get; set; }
        public Nullable<System.DateTime> modify_time { get; set; }
        public string modify_user { get; set; }
        public Nullable<System.DateTime> sign_modify_time { get; set; }
        public string sign_modify_user { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<System.DateTime> delete_time { get; set; }
    }
}