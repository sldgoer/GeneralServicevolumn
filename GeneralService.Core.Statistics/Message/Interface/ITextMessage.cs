using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Message.Interface
{
    using Models;
    interface ITextMessage
    {
        CMPP_CONNECT_RESP ConnectToISMG(CMPP_CONNECT ConnectionObject);

        object Send(string Mobile,string Content);
        void BatchSend(List<string> MobileList, string Content);

        object Summary(DateTime Date);
        object SummaryByType(DateTime Date, string Service_Id);

        //object 

    }
}
