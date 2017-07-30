using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenaralService.Utility.TextFileUtility
{
    using System.IO;
    public class txtContentHandler
    {
        public List<string> getTxtAllLinesString(string FileName)
        {
            List<string> _txtLines = new List<string>();
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs,Encoding.GetEncoding("gb2312"));

                while (sr.Peek() >= 0)
                {
                    _txtLines.Add(sr.ReadLine());
                }

                fs.Close();
                sr.Close();

                return _txtLines;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
