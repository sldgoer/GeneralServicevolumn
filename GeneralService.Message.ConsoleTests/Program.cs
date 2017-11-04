using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Message.ConsoleTests
{
    using Models;
    
    class  Program
    {
        static void Main(string[] args)
        {
            TextMessage tm = new TextMessage("106573401021", "999999", "MGD0019900", "J01615", "RMZVv%9U", "2.0", "211.139.144.201", 7890);
            tm.Socket_Connected += new EventHandler<Models.ISMGEventArgs>(SocketConnectedEventHandler);
            tm.ISMG_Registed += new EventHandler<ISMGEventArgs>(IsmgRegistedEventHandler);

            //tm.RegisterToISMG();
           
                //Assert.Fail();
                //return;
          

            Console.ReadKey();

            //while (true) {  }

            //Assert.Fail();

        }

        private static void SocketConnectedEventHandler(object sender, ISMGEventArgs e)
        {
            TextMessage tm = (TextMessage)sender;
            
            Console.WriteLine("SocketConnected event up!!!" + e.Message);

            tm.RegisterToISMG();

        }

        private static void IsmgRegistedEventHandler(object sender,ISMGEventArgs e)
        {
            Console.WriteLine("Congraturations!! Register is OK!!");

        }

    }
}
