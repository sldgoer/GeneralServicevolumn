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
    
    public partial class A050Sms
    {
        public int id { get; set; }
        public long smsId { get; set; }
        public string telNo { get; set; }
        public string sendContent { get; set; }
        public Nullable<int> smsState { get; set; }
        public string smsDesc { get; set; }
        public Nullable<System.DateTime> rptTime { get; set; }
        public Nullable<System.DateTime> ondate { get; set; }
        public byte[] tsp { get; set; }
    }
}
