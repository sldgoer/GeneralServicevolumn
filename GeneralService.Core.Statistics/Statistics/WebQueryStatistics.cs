using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Core.Statistics
{
    using GeneralService.Utility.FileUtility;
    using GenaralService.Utility.TextFileUtility;

    public class WebQueryStatistics
    {
        FilesHandler filesHandler = new FilesHandler();
        txtContentHandler txtHandler = new txtContentHandler();

        public int getWebQueryStatistics(string DirectoryOfLog, DateTime date)
        {
            var logFilesNameList = getLogFilesName(DirectoryOfLog);
            var logFilesNameInDate = getLogFilesNameByDate(logFilesNameList, date);

            return getWebQueryStatistics(logFilesNameInDate);
        }
        private int getWebQueryStatistics(List<string> LogFilesName)
        {
            int _WebQueryCount = 0;
            foreach (var fn in LogFilesName)
            {
                var res = txtHandler.getTxtAllLinesString(fn);
                int count = res.Count(x => x.Contains("LoginInfo"));
                _WebQueryCount += count;
            }

            return _WebQueryCount;
        }

        private List<string> getLogFilesName(string DirectoryOfLog)
        {
            return filesHandler.getFilenamesFromFolder(DirectoryOfLog, @"*.log");
        }

        private List<string> getLogFilesNameByDate(List<string> FilesNameList, DateTime date)
        {
            List<string> logFilesNameInDate = new List<string>();

            foreach (var fn in FilesNameList)
            {
                var fileDate = filesHandler.getFileDateFromName(fn.ToString(), fn.LastIndexOf(@"\") + 1, 10);

                if (fileDate.Year == date.Year && fileDate.Month == date.Month)
                {
                    logFilesNameInDate.Add(fn);
                }
            }
            return logFilesNameInDate;

            //return FilesNameList.Where(x => { filesHandler.getFileDateFromName }).ToList();
        }
    }
}
