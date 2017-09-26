using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Message.Interface
{
    interface ITextMessage
    {
        object ConnectToISMG(object ConnectionObject);

        object Send(string Mobile,string Content);
        void BatchSend(List<string> MobileList, string Content);

        object Summary(DateTime Date);
        object SummaryByType(DateTime Date, string Service_Id);

        //object 

    }
}
