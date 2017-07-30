using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textFileTest
{
    using GenaralService.Utility.FileUtility;
    using GenaralService.Utility.TextFileUtility;
    class Program
    {
        static void Main(string[] args)
        {
            FilesHandler fh = new FilesHandler();
            txtContentHandler tch = new txtContentHandler();
            var fn = fh.getFilenamesFromFolder(@"F:\Log", @"*.log");


            var res=tch.getTxtAllLinesString(fn[0]);

            int count = res.Count(x => x.Contains("PersonInfo"));

            Console.WriteLine(count);

            //foreach(var s in res)
            //{
            //    Console.WriteLine(s);
            //}
            Console.ReadKey();
        }
    }
}
